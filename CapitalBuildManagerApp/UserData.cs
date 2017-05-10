using EVE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalBuildManagerApp
{
	[SettingsSerializeAs(SettingsSerializeAs.Xml)]
	public class UserData
	{
		private Dictionary<long, XMLAPI> _apis { get; set; }

		// API Data
		private BPOList _bpos;
		private BPOList _bpcs;
		private ItemList _assets;
		private List<IndustryJob> _indyJobs;
		private ItemList _indyJobProducts;

		public BPOList BPCs { get { return this._bpcs; } }
		public BPOList BPOs { get { return this._bpos; } }
		public ItemList Assets { get { return this._assets; } }
		public List<IndustryJob> IndustryJobs { get { return this._indyJobs; } }
		public ItemList IndustryJobProducts { get { return this._indyJobProducts; } }

		public ObservableCollection<Job> Jobs { get; set; }

		public List<XMLAPI> APIs {
			get
			{
				return this._apis.Values.ToList();
			}
		}

		// API Data
		
		public UserData()
		{
			this._apis = new Dictionary<long, XMLAPI>();
			//this._apis.Add(6009295, new XMLAPI("6009295", "JEFFBX1N6HjnksZuUbLwQngH3YHVCOvd7VgJTZSRWIGUeJVqXYnZJBNbC5JagyC0"));

			UpdateFromAPIs();

			this.Jobs = new ObservableCollection<Job>();


		}

		public void AddAPI(XMLAPI api)
		{
			this._apis.Add(long.Parse(api.KeyID), api);
		}

		public void RemoveAPI(long keyID)
		{
			this._apis.Remove(keyID);
		}

		public void UpdateFromAPIs()
		{
			foreach(XMLAPI api in this._apis.Values)
			{
				api.UpdateFromAPI();
			}

			this._bpos = this.getBPOs();
			this._bpcs = this.getBPCs();
			this._assets = this.getAssets();
			this._indyJobs = this.getIndustryJobs();
			this._indyJobProducts = this.getIndustryJobProducts();
		}

		private ItemList getAssets()
		{
			ItemList total = new ItemList();
			foreach(XMLAPI api in this._apis.Values)
			{
				total += api.getAssets();
			}

			return total;
		}

		private BPOList getBPCs()
		{
			BPOList total = new BPOList();
			foreach (XMLAPI api in this._apis.Values) {
				total += api.getBPCs();
				
			}

			return total;
		}

		private BPOList getBPOs()
		{
			BPOList total = new BPOList();
			foreach (XMLAPI api in this._apis.Values)
			{
				total += api.getBPOs();
				
			}

			return total;
		}

		private List<IndustryJob> getIndustryJobs()
		{
			List<IndustryJob> total = new List<IndustryJob>();
			foreach (XMLAPI api in this._apis.Values)
			{
				foreach (IndustryJob job in api.getIndustryJobs())
					{
						total.Add(job);
					}
				
			}

			return total;
		}

		private ItemList getIndustryJobProducts()
		{
			ItemList total = new ItemList();
			foreach (XMLAPI api in this._apis.Values)
			{
				total += api.getIndustryJobProducts();
			}

			return total;
		}

	}
}
