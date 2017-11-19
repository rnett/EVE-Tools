using Newtonsoft.Json.Linq;
using SDEModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE
{
    public class TrainingSkill
    {
        public skill Skill;
        public int TrainingLevel { get; set; }


        public int InvestedSPInLevel
        {
            get
            {
                return InvestedSPInSkill - LevelStartSP;
            }
        }
        public int InvestedSPInSkill
        {
            get
            {
                return LevelEndSP - RemainingSP;
            }
        }

        public int RemainingSP { get { return (int)(RemainingTime.TotalHours * SPPerHour); } }

        public int TrainingStartSP { get; set; }
        public int LevelStartSP { get; set; }
        public int LevelEndSP { get; set; }
        public int SPForLevel { get { return LevelEndSP - LevelStartSP; } }
        public int SPForTrain { get { return LevelEndSP - TrainingStartSP; } }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public double SPPerHour { get { return SPForTrain / TotalTime.TotalHours; } }

        public TimeSpan RemainingTime
        {
            get
            {
                return EndDate - (DateTime.Compare(DateTime.Now.ToUniversalTime(), StartDate) < 0 ? StartDate : DateTime.Now.ToUniversalTime());
            }
        }

        public TimeSpan TotalTime
        {
            get
            {
                return EndDate - StartDate;
            }
        }

        public TrainingSkill(int skillID, int level, int trainingStartSP, int levelStartSP, int levelEndSP, DateTime endDate, DateTime startDate)
        {
            this.Skill = SDEEntities.SDE.GetSkillFromID(skillID).First();
            this.TrainingLevel = level;
            this.TrainingStartSP = trainingStartSP;
            this.LevelEndSP = levelEndSP;
            this.LevelStartSP = levelStartSP;
            this.EndDate = endDate;
            this.StartDate = startDate;
        }

        public TrainingSkill(JObject json) : this((int)json["skill_id"], (int)json["finished_level"], (int)json["training_start_sp"], (int)json["level_start_sp"], (int)json["level_end_sp"], DateTime.Parse((string)json["finish_date"]), DateTime.Parse((string)json["start_date"]))
        {

        }

        public int HoursToMakeSP(int sp)
        {
            return sp / (int)SPPerHour;
        }

        public int SPMadeAt(DateTime time)
        {
            return (int)(SPPerHour * (time - DateTime.Now.ToUniversalTime()).TotalHours);
        }
        public override string ToString()
        {
            return Skill.typeName + " " + TrainingLevel;
        }

    }
}
