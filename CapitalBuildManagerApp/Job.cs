using EVE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalBuildManagerApp
{
	public class Job
	{
		public invtype Type { get; }
		public int Amount { get; }

		public DateTime TimeEntered { get; }

		public bool BpcsOnly { get; set; }

		public Job(invtype type, int amount, DateTime timeEntered, bool bpcsOnly = false)
		{
			this.Type = type;
			this.Amount = amount;
			this.TimeEntered = timeEntered;
			this.BpcsOnly = bpcsOnly;
		}
	}
}
