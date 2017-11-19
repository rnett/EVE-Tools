using SDEModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE
{
    public class StructureRigEfficiencyModifier
    {
        public static readonly StructureRigEfficiencyModifier Equipment = new StructureRigEfficiencyModifier(2538, new List<int>() { 7, 22, 20, 2 }, new List<int>());
        public static readonly StructureRigEfficiencyModifier Ammo = new StructureRigEfficiencyModifier(2540, new List<int>() { 8 }, new List<int>());
        public static readonly StructureRigEfficiencyModifier Drone = new StructureRigEfficiencyModifier(2542, new List<int>() { 18, 87 }, new List<int>());
        public static readonly StructureRigEfficiencyModifier BasSmallShip = new StructureRigEfficiencyModifier(2544, new List<int>() { }, new List<int>() { 31, 25, 420 });
        public static readonly StructureRigEfficiencyModifier BasMediumShip = new StructureRigEfficiencyModifier(2546, new List<int>() { }, new List<int>() { 1201, 26, 419, 28, 463 });
        public static readonly StructureRigEfficiencyModifier BasLargeShip = new StructureRigEfficiencyModifier(2548, new List<int>() { }, new List<int>() { 27, 513, 941 });
        public static readonly StructureRigEfficiencyModifier AdvSmallShip = new StructureRigEfficiencyModifier(2550, new List<int>() { }, new List<int>() { 324, 830, 831, 834, 893, 1283, 1527, 541, 1534, 1305 });
        public static readonly StructureRigEfficiencyModifier AdvMediumShip = new StructureRigEfficiencyModifier(2552, new List<int>() { 32 }, new List<int>() { 358, 832, 833, 894, 906, 540, 380, 1202, 543, 963 });
        public static readonly StructureRigEfficiencyModifier AdvLargeShip = new StructureRigEfficiencyModifier(2555, new List<int>() {}, new List<int>() { 900, 898, 902 });
        public static readonly StructureRigEfficiencyModifier AdvComp = new StructureRigEfficiencyModifier(2557, new List<int>() { }, new List<int>() { 334, 332, 716, 964 });
        public static readonly StructureRigEfficiencyModifier BasCapComp = new StructureRigEfficiencyModifier(2559, new List<int>() { }, new List<int>() { 873 });
        public static readonly StructureRigEfficiencyModifier Structure = new StructureRigEfficiencyModifier(2561, new List<int>() { 65, 66, 23 }, new List<int>() { 1136 });
        public static readonly StructureRigEfficiencyModifier CapShip = new StructureRigEfficiencyModifier(2575, new List<int>() { }, new List<int>() { 30, 485, 547, 659, 883, 1538 });
        public static readonly StructureRigEfficiencyModifier AllShips = new StructureRigEfficiencyModifier(2591, new List<int>() { 6, 32 }, new List<int>());
        public static readonly StructureRigEfficiencyModifier AdvCapComp = new StructureRigEfficiencyModifier(2658, new List<int>() { }, new List<int>() { 913 });

        public static readonly Dictionary<int, StructureRigEfficiencyModifier> AllModifiers = new Dictionary<int, StructureRigEfficiencyModifier>();

        public int BaseAttributeID { get; }
        public int MaterialAttributeID { get => BaseAttributeID; }
        public int TimeAttributeID { get => BaseAttributeID + 1; }

        public List<int> Categories;
        public List<int> Groups;

        private StructureRigEfficiencyModifier(int attributeID, List<int> categories, List<int> groups)
        {
            this.BaseAttributeID = attributeID;
            this.Categories = categories;
            this.Groups = groups;

            AllModifiers.Add(BaseAttributeID, this);
        }

        public bool Affects(invType productType)
        {
            return Groups.Contains(productType.invGroup.groupID) || Categories.Contains(productType.invGroup.invCategory.categoryID);
        }

    }

    public class StructureRig
    {

        public static readonly Dictionary<invType, StructureRig> EfficiencyRigs = new Dictionary<invType, StructureRig>();
        public static Dictionary<invType, StructureRig> MediumRigs { get => EfficiencyRigs.Select(e=>e.Value).Where(r=>r.Type.typeName.Contains("M-Set")).ToDictionary(e => e.Type); }
        public static Dictionary<invType, StructureRig> LargeRigs { get => EfficiencyRigs.Select(e => e.Value).Where(r => r.Type.typeName.Contains("L-Set")).ToDictionary(e => e.Type); }
        public static Dictionary<invType, StructureRig> XLargeRigs { get => EfficiencyRigs.Select(e => e.Value).Where(r => r.Type.typeName.Contains("XL-Set")).ToDictionary(e => e.Type); }

        public static dgmAttributeType RigMEMultiplier = SDEEntities.SDE.dgmAttributeTypes.Find(2594);
        public static dgmAttributeType RigTEMultiplier = SDEEntities.SDE.dgmAttributeTypes.Find(2593);

        public invType Type;
        public List<StructureRigEfficiencyModifier> MEModifiers;
        public List<StructureRigEfficiencyModifier> TEModifiers;

        static StructureRig()
        {
            invCategory catagory = SDEEntities.SDE.invCategories.Find(66);

            foreach(invGroup group in catagory)
            {
                if(group.groupName.Contains("Structure Assembly Rig"))
                {
                    foreach (invType type in group)
                        EfficiencyRigs.Add(type, new StructureRig(type));
                }

            }

        }

        private StructureRig(invType type)
        {
            List<int> Attributes = new List<int>();
            Type = type;

            foreach (dgmEffect effect in type.dgmTypeEffects.Select(e => e.dgmEffect))
            {
                foreach(dgmEffectsModifierInfo mod in effect.dgmEffectsModifierInfoes)
                {
                    Attributes.Add(mod.modifiedAttribute.attributeID);
                }
            }

            foreach (int attr in Attributes)
            {
                if (StructureRigEfficiencyModifier.AllModifiers.ContainsKey(attr)) // it is the me attribute
                {
                    this.MEModifiers.Add(StructureRigEfficiencyModifier.AllModifiers[attr]);
                } else if (StructureRigEfficiencyModifier.AllModifiers.ContainsKey(attr-1)) // it is the te attribute
                {
                    this.TEModifiers.Add(StructureRigEfficiencyModifier.AllModifiers[attr-1]);
                }
            }

        }

        public double MEMultiplier(invType buildingProduct)
        {
            double mult = 1;

            foreach(StructureRigEfficiencyModifier mod in MEModifiers)
            {
                if (mod.Affects(buildingProduct))
                {
                    double rigMult = 1D - ( Type.GetAttribute(RigMEMultiplier).IntOrFloatValue / 100D );

                    if (rigMult < mult)
                        mult = rigMult;

                }
            }
            return mult;
        }

        public double TEMultiplier(invType buildingProduct)
        {
            double mult = 1;

            foreach (StructureRigEfficiencyModifier mod in MEModifiers)
            {
                if (mod.Affects(buildingProduct))
                {
                    double rigMult = 1D - (Type.GetAttribute(RigTEMultiplier).IntOrFloatValue / 100D);

                    if (rigMult < mult)
                        mult = rigMult;

                }
            }
            return mult;
        }

    }

    public enum StructureCanBuild { Subcaps, Capitals, Supers}
    public class IndyStructure
    {

        public static invType Sotiyo = SDEEntities.SDE.GetTypeFromName("Sotiyo").First();
        public static invType Azbel = SDEEntities.SDE.GetTypeFromName("Azbel").First();
        public static invType Raitaru = SDEEntities.SDE.GetTypeFromName("Raitaru").First();

        public StructureCanBuild CanBuild { get; }
        public Location Structure { get; }
        public List<StructureRig> Rigs { get; }
        public double BonusMultiplier {
            get {
                if (Structure.System.security.Value > 0.5)
                    return 1;
                else if (Structure.System.security.Value > 0)
                    return 1.9;
                else
                    return 2.1;
            }
        }

        public IndyStructure(Location structure, List<StructureRig> rigs)
        {
            Structure = structure;
            Rigs = rigs;

            switch (structure.StructureType.typeName)
            {
                case "Sotiyo":
                    CanBuild = StructureCanBuild.Supers;
                    break;
                case "Azbel":
                    CanBuild = StructureCanBuild.Capitals;
                    break;
                default:
                    CanBuild = StructureCanBuild.Subcaps;
                    break;
            }

        }

        public double MEMultiplier(invType buildingProduct)
        {
            double mult = 0.99;

            foreach(StructureRig rig in Rigs)
            {
                mult *= rig.MEMultiplier(buildingProduct);
            }
            return mult;
        }

        public double TEMultiplier(invType buildingProduct)
        {
            double mult = 0.99;

            foreach (StructureRig rig in Rigs)
            {
                mult *= rig.MEMultiplier(buildingProduct);
            }
            return mult;
        }

    }

}
