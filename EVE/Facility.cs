using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE
{
	public class Facility
	{
		public class Structure
		{
			private string name;
			private double baseME;
			private double baseTE;
			private double baseTaxMult;

			private Structure(string name, double baseME, double baseTE, double baseTaxMult)
			{
				this.name = name;
				this.baseME = baseME;
				this.baseTE = baseTE;
				this.baseTaxMult = baseTaxMult;
			}

			public class Rig
			{
				private IDictionary<invtype, double> mes;
				private IDictionary<invtype, double> tes;
				private string name;
			}

			public static readonly Structure Raitaru = new Structure("Raitaru", 0.99, 0.85, 0.97);
			public static readonly Structure Azbel = new Structure("Azbel", 0.99, 0.80, 0.96);
			public static readonly Structure Sotiyo = new Structure("Sotiyo", 0.99, 0.70, 0.95);
		}

		private Structure structure;
		private Tuple<Structure.Rig, Structure.Rig, Structure.Rig> rigs;

	}

}
