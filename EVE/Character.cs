using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace EVE
{
    public class Character
    {

        public static readonly Dictionary<int, Character> KnownCharacters = new Dictionary<int, Character>();

	    private const string _crestClient = "ec355eed5c8748a5b36c3c178d3b79f8";
	    private const string _crestSecret = "K4Tl1QT9pOt5bJlhY3KwlezYzdHpMgV1XbNYVbmR";
        // Character
        public string RefreshToken { get; private set; }
        public string AuthToken {
            get {
                if (DateTime.Now <= authTokenExpires)
                    return _authToken;
                else
                {
                    updateAuthToken();
                    return _authToken;
                }

            }
            private set {
                _authToken = value;
            }
        }
        private string _authToken;
        private DateTime authTokenExpires;

        public int CharacterID;
        public string CharacterName;

        public int ISK;
        public TimeSpan JumpFatigue;
        public string PictureURL;

        //public DateTime OmegaExpiration { get; }
        //public bool Omega { get; }

        // Industry
        public List<IndustryJob> IndustryJobs { get; } = new List<IndustryJob>();

        // Contracts
        public List<Contract> AllContracts { get; } = new List<Contract>();
        public List<Contract> OutstandingItemExchangesToMe { get; } = new List<Contract>();
        public List<Contract> UnfinishedCouriers { get; } = new List<Contract>();
        public List<Contract> RecentlyCompleted { get; } = new List<Contract>();

        // Skills
        public bool Training { get; }

        public List<TrainingSkill> SkillQueue { get; }
        public TrainingSkill CurrentTrain { get; }
        public int TotalSP { get; set; }

        public Attributes Attributes;

        public List<DateTime> ExtractionPoints;

        public Character(string refreshToken)
        {
            RefreshToken = refreshToken;
            updateAuthToken();

            // character ID
            HttpWebRequest web = (HttpWebRequest)WebRequest.CreateHttp("https://login.eveonline.com/oauth/verify");
            web.Method = "GET";
            web.Headers.Add("Authorization", "Bearer " + AuthToken);
            web.ContentLength = 0;

            var response = web.GetResponse();
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                string text = sr.ReadToEnd();
                JObject res = JObject.Parse(text);
                this.CharacterID = int.Parse((string)res["CharacterID"]);
                this.CharacterName = (string)res["CharacterName"];
            }
            JToken exp = JObject.Parse(esiCharacter("fatigue"))["jump_fatigue_expire_date"];
            if (exp == null)
            {
                JumpFatigue = new TimeSpan(0);
            }
            else
            {
                DateTime expire = DateTime.Parse((string)exp);
                JumpFatigue = expire.Subtract(DateTime.Now);

                if (JumpFatigue < TimeSpan.Zero)
                    JumpFatigue = TimeSpan.Zero;

            }

            if (JumpFatigue.TotalMilliseconds < 0)
                JumpFatigue = new TimeSpan(0);

            ISK = (int)double.Parse(esiCharacter("wallet"));

            PictureURL = "https://imageserver.eveonline.com/Character/" + CharacterID + "_128.jpg";

            // industry jobs
            //TODO check once I have some jobs running
            string indyJobs = esiCharacter("industry/jobs");
            JArray jobs = JArray.Parse(indyJobs);

            foreach(JObject obj in jobs)
            {
                IndustryJobs.Add(obj.ToObject<IndustryJob>());
            }

            string contractsString = esiCharacter("contracts");
            JArray contracts = JArray.Parse(contractsString);

            foreach(JObject obj in contracts){
                Contract c = obj.ToObject<Contract>();
                AllContracts.Add(c);
                if (c.Type == ContractType.Courier && c.Status != ContractStatus.Completed)
                    UnfinishedCouriers.Add(c);

                if (c.Type == ContractType.ItemExchange && c.AssigneeID == CharacterID && c.Status != ContractStatus.Completed)
                    OutstandingItemExchangesToMe.Add(c);

                if (c.Status == ContractStatus.Completed && c.DateCompleted >= DateTime.Now.AddDays(-1))
                    RecentlyCompleted.Add(c);

            }

            Training = true;
            Attributes = JObject.Parse(esiCharacter("attributes")).ToObject<Attributes>();
            SkillQueue = new List<TrainingSkill>();
            ExtractionPoints = new List<DateTime>();

            TotalSP = (int)JObject.Parse(esiCharacter("skills"))["total_sp"];

            JArray queue = JArray.Parse(esiCharacter("skillqueue"));

            foreach(JObject obj in queue)
            {
                try
                {
                    string start = (string)obj["start_date"];
                    if (start == null || start == "")
                        break;
                }
                catch (Exception e)
                {
                    Training = false;
                    break;
                }

                TrainingSkill ts = new TrainingSkill(obj);
                    if (ts.RemainingSP >= 0)
                        SkillQueue.Add(ts);
            }

            int total = TotalSP - 5000000;

            foreach(TrainingSkill skill in SkillQueue)
            {
                if(total + skill.RemainingSP > 500000)
                {
                    ExtractionPoints.Add(skill.StartDate.AddHours( skill.HoursToMakeSP(500000 - total) ));
                    total = skill.RemainingSP - (500000 - total);
                } else
                {
                    total += skill.RemainingSP;
                }
            }

            if (SkillQueue.Count == 0 || SkillQueue[0].StartDate == null)
                Training = false;

            if (Training)
                CurrentTrain = SkillQueue[0];
            else
                CurrentTrain = null;

            KnownCharacters.Add(this.CharacterID, this);
        }

        private void updateAuthToken()
        {
            HttpWebRequest web = (HttpWebRequest)WebRequest.CreateHttp("https://login.eveonline.com/oauth/token");
            web.Method = "POST";
            web.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(_crestClient + ":" + _crestSecret)));
            
            var postData = "refresh_token="+ RefreshToken;
            postData += "&grant_type=refresh_token";
            var data = Encoding.ASCII.GetBytes(postData);
            web.ContentType = "application/x-www-form-urlencoded";
            web.ContentLength = data.Length;

            using (var stream = web.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            
            var response = web.GetResponse();
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                string text = sr.ReadToEnd();
                JObject res = JObject.Parse(text);
                this.RefreshToken = (string)res["refresh_token"];
                this.AuthToken = (string)res["access_token"];
                this.authTokenExpires = DateTime.Now.AddSeconds(double.Parse((string)res["expires_in"]));
            }

        }

        public string esiCharacter(string endpoint)
        {
            string url = "https://esi.tech.ccp.is/latest/characters/" + CharacterID + "/" + endpoint + "/?datasource=tranquility&token=" + AuthToken;
            if(endpoint == "")
            {
                url = "https://esi.tech.ccp.is/latest/characters/" + CharacterID + "/";
            }

            HttpWebRequest web = (HttpWebRequest)WebRequest.CreateHttp(url);
            web.Method = "GET";
            web.ContentLength = 0;

            var response = web.GetResponse();
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                return sr.ReadToEnd();
            }

        }

        public override string ToString()
        {
            return CharacterName;
        }

    }
}
