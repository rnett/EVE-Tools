using EVE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SDEModel
{

    public partial class SDEEntities
    {
        public static readonly SDEEntities SDE = new SDEEntities();
    }

    public partial class mapSolarSystem
    {
        public int GetShortestPath(mapSolarSystem dest)
        {
            Dictionary<mapSolarSystem, int> distance = new Dictionary<mapSolarSystem, int>();

            if (dest.jumpsTo.Count == 0)
            {
                return -1;
            }

            Queue<mapSolarSystem> Q = new Queue<mapSolarSystem>();
            Q.Enqueue(this);
            distance.Add(this, 0);

            while (Q.Count > 0)
            {
                mapSolarSystem s = Q.Dequeue();
                int dist = distance[s];

                foreach(mapSolarSystemJump child in s.jumpsFrom)
                {
                    if (child.toSystem.solarSystemID == dest.solarSystemID)
                        return dist + 1;


                    if (!distance.ContainsKey(child.toSystem))
                    {
                        distance.Add(child.toSystem, dist + 1);
                        Q.Enqueue(child.toSystem);
                    }
                }

            }

            return -1;
        }
    }

	public partial class invType
	{

		public override string ToString()
		{
			return this.typeName;
		}

		public override bool Equals(object obj)
		{
			if (obj.GetType() != this.GetType())
				return false;

			invType inv = (invType)obj;

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

        private invMarketGroup _topmost;

        public invMarketGroup TopmostMarketGroup {
            get {
                if (_topmost != null)
                    return _topmost;
                else
                {
                    _topmost = this.invMarketGroup;

                    if (_topmost == null)
                        return _topmost;

                    while (_topmost.parent != null)
                        _topmost = _topmost.parent;

                    return _topmost;
                }
            }
        }

        public dgmTypeAttribute GetAttribute(int attributeID) {
            return SDEEntities.SDE.dgmTypeAttributes.Find(typeID, attributeID);
        }

        public dgmTypeAttribute GetAttribute(dgmAttributeType attribute)
        {
            return GetAttribute(attribute.attributeID);
        }

    }

	public partial class ore
	{
		public override string ToString()
		{
			return this.name;
		}
    }
    public partial class skill
    {
        public SkillAttribute Primary
        {
            get
            {
                return (SkillAttribute)this.primaryAttr;
            }
        }
        public SkillAttribute Secondary
        {
            get
            {
                return (SkillAttribute)this.secondaryAttr;
            }
        }

    }

    public partial class invGroup : IEnumerable<invType>
    {
        public IEnumerator<invType> GetEnumerator()
        {
            return invTypes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return invTypes.GetEnumerator();
        }
    }

    public partial class invCategory : IEnumerable<invGroup>
    {
        public IEnumerator<invGroup> GetEnumerator()
        {
            return invGroups.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return invGroups.GetEnumerator();
        }
    }

    public partial class invMarketGroup : IEnumerable<invType>
    {
        public IEnumerator<invType> GetEnumerator()
        {
            return typesInGroup.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return typesInGroup.GetEnumerator();
        }
    }

    public partial class mapConstellation : IEnumerable<mapSolarSystem>
    {
        public IEnumerator<mapSolarSystem> GetEnumerator()
        {
            return mapSolarSystems.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return mapSolarSystems.GetEnumerator();
        }
    }

    public partial class mapRegion : IEnumerable<mapConstellation>
    {
        public IEnumerator<mapConstellation> GetEnumerator()
        {
            return mapConstellations.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return mapConstellations.GetEnumerator();
        }
    }

    public partial class dgmTypeAttribute
    {
        public int IntOrFloatValue { get => this.valueInt.HasValue ? this.valueInt.Value : (int)this.valueFloat.GetValueOrDefault() ; }
    }

    public partial class GetAttribute_Result
    {
        public int IntOrFloatValue { get => this.valueInt.HasValue ? this.valueInt.Value : (int)this.valueFloat.GetValueOrDefault() ; }
    }

}


namespace EVE
{
    public static class EnumExtensions
    {
        public static string GetDescription<T>(this T enumerationValue)
    where T : struct
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }

            //Tries to find a DescriptionAttribute for a potential friendly name
            //for the enum
            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    //Pull out the description value
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            //If we have no description attribute, just return the ToString of the enum
            return enumerationValue.ToString();
        }
    }
}
