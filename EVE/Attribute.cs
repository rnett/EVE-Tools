using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE
{
    public enum SkillAttribute {Charisma, Intelligence , Memory, Perception, Willpower};

    public class Attributes
    {
        [JsonProperty("charisma")]
        public int Charisma;

        [JsonProperty("intelligence")]
        public int Intelligence;

        [JsonProperty("memory")]
        public int Memory;

        [JsonProperty("perception")]
        public int Perception;

        [JsonProperty("willpower")]
        public int Willpower;

        public Attributes(int cha, int inte, int mem, int per, int wil)
        {
            Charisma = cha;
            Intelligence = inte;
            Memory = mem;
            Perception = per;
            Willpower = wil;
        }

        public int ValueOf(SkillAttribute attr)
        {
            switch (attr)
            {
                case SkillAttribute.Charisma:
                    return Charisma;
                case SkillAttribute.Intelligence:
                    return Intelligence;
                case SkillAttribute.Memory:
                    return Memory;
                case SkillAttribute.Perception:
                    return Perception;
                case SkillAttribute.Willpower:
                    return Willpower;
            }
            return -1;
        }

    }
}