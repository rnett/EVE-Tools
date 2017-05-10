using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalBuildManagerApp
{
	public class METEData
	{

		public double BPME { get; set; }
		public double BPTE { get; set; }
		public double FacilityME { get; set; }
		public double FacilityTE { get; set; }
		public double SkillME { get; set; }
		public double SkillTE { get; set; }

		public METEData(double bpme, double bpte, double facme, double facte, double skme, double skte)
		{
			this.BPME = bpme;
			this.BPTE = bpte;
			this.FacilityME = facme;
			this.FacilityTE = facte;
			this.SkillME = skme;
			this.SkillTE = skte;
		}

		public METEData()
		{
			this.BPME = -1;
			this.BPTE = -1;
			this.FacilityME = -1;
			this.FacilityTE = -1;
			this.SkillME = -1;
			this.SkillTE = -1;
		}

		public double TotalME { get
			{
				return 100D - ( (100D - (BPME == -1 ? 0 : BPME)) * (100D - (FacilityME == -1 ? 0 : FacilityME)) * (100D - (SkillME == -1 ? 0 : SkillME)) / 10000D ); 
			}
		}

		public double TotalTE
		{
			get
			{
				return 100D - ((100D -( BPTE == -1 ? 0 : BPTE)) * (100D - (FacilityTE == -1 ? 0 : FacilityTE)) * (100D - (SkillTE == -1 ? 0 : SkillTE)) / 10000D );
			}
		}

		public double TotalMEAsMultiplier
		{
			get
			{
				return (100D - TotalME) / 100D;
			}
		}

		public double TotalTEAsMultiplier
		{
			get
			{
				return (100D - TotalTE) / 100D;
			}
		}

		public string[] ToStrArray()
		{
			return new string[] {
				BPME == -1?"":BPME.ToString(),
				BPTE == -1?"":BPTE.ToString(),
				FacilityME == -1?"":FacilityME.ToString(),
				FacilityTE == -1?"":FacilityTE.ToString(),
				SkillME == -1?"":SkillME.ToString(),
				SkillTE == -1?"":SkillTE.ToString()
			};
		}

	}
}
