using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE
{
	public partial class invtype
	{

		public override string ToString()
		{
			return this.typeName;
		}

		public override bool Equals(object obj)
		{
			if (obj.GetType() != this.GetType())
				return false;

			invtype inv = (invtype)obj;

			return inv.typeID == this.typeID;

		}

		public override int GetHashCode()
		{
			return this.typeID;
		}

		public ItemList getMats(int amount, double MEMultiplier)
		{
			var db = new SDEEntities();
			ItemList mats = new ItemList(db.GetMats(this.typeID, 1).ToList());

			mats *= amount;
			mats *= MEMultiplier;

			return mats;
		}

		public bool isBaseMat()
		{
			var db = new SDEEntities();
			return db.GetMats(this.typeID, 1).Count() == 0;
		}

		public bool isMineral()
		{
			return this.groupID == 18;
		}
	}

	public partial class ore
	{
		public override string ToString()
		{
			return this.name;
		}
	}

}
