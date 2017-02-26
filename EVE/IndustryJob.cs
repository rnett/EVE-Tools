using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE
{
	[SettingsSerializeAs(SettingsSerializeAs.Xml)]
	public class IndustryJob
	{

		public BPO Blueprint { get; }
		public int ActivityID { get; }
		public DateTime EndDate { get; }
		public int Runs { get; }
		// add status?

		public industryactivity IndustryActivity { get
			{
				return Blueprint.Type.blueprint_industryactivities.Where(x => x.activityID == this.ActivityID).First();
			}
		}

		public ItemList Products { 
			get
			{
				 return new ItemList(this.IndustryActivity.industryactivityproducts) * Runs;
			}
		}

		public IndustryJob(BPO blueprint, int runs, int activityID, DateTime endDate)
		{
			this.Blueprint = blueprint;
			this.Runs = runs;
			this.ActivityID = activityID;
			this.EndDate = endDate;
		}

		public override string ToString()
		{
			return Blueprint.Type.ToString() + " x" + Runs + " ends " + EndDate;
		}

	}
}
