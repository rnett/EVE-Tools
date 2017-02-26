using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EVE
{
	public class XMLAPI
	{
		public string KeyID { get; }
		public string VCode { get; }

		private CharacterData[] _characters = new CharacterData[3];
		public CharacterData[] Characters { get { return this._characters; } }

		public XMLAPI(string keyID, string vCode)
		{
			this.KeyID = keyID;
			this.VCode = vCode;

			//TODO verify
			string url = "https://api.eveonline.com/account/APIKeyInfo.xml.aspx?keyID=" + keyID + "&vCode=" + vCode;
			HttpWebRequest getRequest = (HttpWebRequest)WebRequest.Create(url);
			HttpWebResponse response = (HttpWebResponse)getRequest.GetResponse();
			string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
			XmlDocument xml = new XmlDocument();
			xml.LoadXml(content);

			//verfy the api has Assets and IndustryJobs endpoints
			long accessMask = long.Parse(xml.GetElementsByTagName("key")[0].Attributes.GetNamedItem("accessMask").Value);

			if((accessMask & 128) == 128 && (accessMask & 2) == 2)
			{

			} else
			{
				throw new Exception("Invalid Access Mask");
			}

			string expirationDate = xml.GetElementsByTagName("key")[0].Attributes.GetNamedItem("expires").Value;

			if(expirationDate != "")
			{
				//throw new Exception("Key has an expiration date");
			}

			// get characters
			XmlNodeList list = xml.GetElementsByTagName("rowset");



			int i = 0;
			foreach(XmlElement element in list[0].ChildNodes)
			{
				_characters[i] = new CharacterData(Int32.Parse(element.GetAttribute("characterID")), element.GetAttribute("characterName"));


				i++;
			}
		}

		public ItemList getAssets()
		{
			ItemList total = new ItemList();
			for(int i = 0; i < 3; i++)
			{
				if(_characters[i] != null)
				{
					total += _characters[i].Assets;
				}
			}

			return total;
		}

		public BPOList getBPCs()
		{
			BPOList total = new BPOList();
			for (int i = 0; i < 3; i++)
			{
				if (_characters[i] != null)
				{
					total += _characters[i].BPCs;
				}
			}

			return total;
		}

		public BPOList getBPOs()
		{
			BPOList total = new BPOList();
			for (int i = 0; i < 3; i++)
			{
				if (_characters[i] != null)
				{
					total += _characters[i].BPOs;
				}
			}

			return total;
		}

		public List<IndustryJob> getIndustryJobs()
		{
			List<IndustryJob> total = new List<IndustryJob>();
			for (int i = 0; i < 3; i++)
			{
				if (_characters[i] != null)
				{
					foreach (IndustryJob job in _characters[i].IndustryJobs)
					{
						total.Add(job);
					}
				}
			}

			return total;
		}

		public ItemList getIndustryJobProducts()
		{
			ItemList total = new ItemList();
			for (int i = 0; i < 3; i++)
			{
				if (_characters[i] != null)
				{
					foreach (IndustryJob job in _characters[i].IndustryJobs)
					{
						total += job.Products;
					}
				}
			}

			return total;
		}

		public void UpdateFromAPI()
		{
			foreach(CharacterData data in _characters)
			{
				data.UpdateFromAPI(this.KeyID, this.VCode);
			}
		}

	}
}
