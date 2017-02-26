using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EVE
{
	[SettingsSerializeAs(SettingsSerializeAs.Xml)]
	public class CharacterData
	{

		private static readonly SDEEntities sde = new SDEEntities();

		private BPOList _bpos;
		private BPOList _bpcs;
		private ItemList _assets;
		private List<IndustryJob> _indyJobs;

		private int _charID;
		private string _charName;

		public BPOList BPCs { get{ return this._bpcs; } }
		public BPOList BPOs { get { return this._bpos; } }

		public ItemList Assets { get { return this._assets; } }
		public List<IndustryJob> IndustryJobs { get { return this._indyJobs; } }
		public int CharacterID { get { return this._charID; } }
		public string CharacterName { get { return this._charName; } }

		public CharacterData(int charID, string charName)
		{
			this._charID = charID;
			this._charName = charName;
		}

		public void UpdateFromAPI(string keyID, string vCode)
		{
			//assets
			string url = "https://api.eveonline.com/char/AssetList.xml.aspx?keyID=" + keyID + "&vCode=" + vCode + "&flat=1&characterID="+this._charID;
			HttpWebRequest getRequest = (HttpWebRequest)WebRequest.Create(url);
			HttpWebResponse response = (HttpWebResponse)getRequest.GetResponse();
			string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
			XmlDocument xml = new XmlDocument();
			xml.LoadXml(content);
			XmlNodeList list = xml.GetElementsByTagName("rowset");

			this._assets = new ItemList();
			foreach (XmlElement element in list[0].ChildNodes)
			{
				if(element.GetAttribute("flag") != "0")
					this._assets.Add(sde.GetTypeFromID( Int32.Parse( element.GetAttribute("typeID") )).First(), Int32.Parse(element.GetAttribute("quantity")));
			}

			// blueprints
			url = "https://api.eveonline.com/char/Blueprints.xml.aspx?keyID=" + keyID + "&vCode=" + vCode + "&characterID=" + this._charID;
			getRequest = (HttpWebRequest)WebRequest.Create(url);
			response = (HttpWebResponse)getRequest.GetResponse();
			content = new StreamReader(response.GetResponseStream()).ReadToEnd();
			xml = new XmlDocument();
			xml.LoadXml(content);
			list = xml.GetElementsByTagName("rowset");

			this._bpcs = new BPOList();
			this._bpos = new BPOList();
			foreach (XmlElement element in list[0].ChildNodes)
			{
				if (element.GetAttribute("flag") != "0") { 

					if(element.GetAttribute("runs") == "-1") // bpo
					{
						this._bpos.Add(new BPO(sde.GetTypeFromID( Int32.Parse(element.GetAttribute("typeID"))).First(), Int32.Parse(element.GetAttribute("materialEfficiency")), Int32.Parse(element.GetAttribute("timeEfficiency")) ), 1);
					} else // bpc
					{
						this._bpcs.Add(new BPO(sde.GetTypeFromID(Int32.Parse(element.GetAttribute("typeID"))).First(), Int32.Parse(element.GetAttribute("materialEfficiency")), Int32.Parse(element.GetAttribute("timeEfficiency"))), Int32.Parse(element.GetAttribute("runs")));
					}
					
				}
			}

			//indy jobs
			url = "https://api.eveonline.com/char/IndustryJobs.xml.aspx?keyID=" + keyID + "&vCode=" + vCode + "&characterID=" + this._charID;
			getRequest = (HttpWebRequest)WebRequest.Create(url);
			response = (HttpWebResponse)getRequest.GetResponse();
			content = new StreamReader(response.GetResponseStream()).ReadToEnd();
			xml = new XmlDocument();
			xml.LoadXml(content);
			list = xml.GetElementsByTagName("rowset");

			this._indyJobs = new List<IndustryJob>();
			foreach (XmlElement element in list[0].ChildNodes)
			{

				string date = element.GetAttribute("endDate");
				DateTime endTime = DateTime.Parse(date);

				this._indyJobs.Add(new IndustryJob(
					new BPO(sde.GetTypeFromID(Int32.Parse(element.GetAttribute("blueprintTypeID"))).First(), 0, 0),
							Int32.Parse(element.GetAttribute("runs")),
							Int32.Parse(element.GetAttribute("activityID")),
							endTime
					));
			}
		}

	}
}
