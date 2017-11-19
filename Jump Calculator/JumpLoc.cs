using EVE;
using Newtonsoft.Json.Linq;
using SDEModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jump_Calculator
{
    public class JumpLoc
    {
        [NotMapped]
        public static readonly Dictionary<long, JumpLoc> JumpLocs = new Dictionary<long, JumpLoc>();

        [Key]
        public long ID { get; set; }
        public string Name { get; set; }
        public LocationType Type { get; set; }

        public int SolarSystemID { get; set; }
        [NotMapped]
        public mapSolarSystem System
        {
            get
            {
                if (_system == null)
                {
                    _system = SDEEntities.SDE.GetSystemFromID(SolarSystemID).FirstOrDefault();
                }
                return _system;
            }
        }
        [NotMapped]
        private mapSolarSystem _system = null;

        public int StructureTypeID { get; set; }
        [NotMapped]
        public invType StructureType
        {
            get
            {
                if (_structureType == null)
                {
                    _structureType = SDEEntities.SDE.GetTypeFromID(StructureTypeID).FirstOrDefault();
                }
                return _structureType;
            }
        }
        [NotMapped]
        private invType _structureType = null;

        private JumpLoc(long id)
        {
            ID = id;
            Type = LocationType.Unknown;
            Name = "Unknown";

            JObject jobj;

            try
            {
                
                string url = "https://esi.tech.ccp.is/latest/universe/structures/" + ID + "/?datasource=tranquility&token=" + LocChar.Character.AuthToken;
                HttpWebRequest web = (HttpWebRequest)WebRequest.CreateHttp(url);
                web.Method = "GET";
                web.ContentLength = 0;

                var response = web.GetResponse();
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    jobj = JObject.Parse(sr.ReadToEnd());
                }


                Name = (string)jobj["name"];
                StructureTypeID = (int)jobj["type_id"];
                SolarSystemID = (int)jobj["solar_system_id"];
                Type = LocationType.Citadel;
            }
            catch (Exception e)
            {
            }


            if (Type == LocationType.Unknown)    // didn't find it looking at structures, look at stations
            {

                try
                {
                    string url = "https://esi.tech.ccp.is/latest/universe/stations/" + ID + "/?datasource=tranquility&token=" + LocChar.Character.AuthToken;
                    HttpWebRequest web = (HttpWebRequest)WebRequest.CreateHttp(url);
                    web.Method = "GET";
                    web.ContentLength = 0;

                    var response = web.GetResponse();
                    using (var sr = new StreamReader(response.GetResponseStream()))
                    {
                        jobj = JObject.Parse(sr.ReadToEnd());
                    }
                    Name = (string)jobj["name"];
                    StructureTypeID = (int)jobj["type_id"];
                    SolarSystemID = (int)jobj["system_id"];
                    Type = LocationType.Station;
                }
                catch (Exception e)
                {
                }


            }

            if (this.Type != LocationType.Unknown)
            {
                JumpLocs.Add(this.ID, this);
                JumpLocationsModel.Model.JumpPoints.Add(this);
            }
        }

        [NotMapped]
        private static long maxID = 0;
        
        public static JumpLoc Get(long id)
        {
            if (id > maxID)
                maxID = id;

            if (JumpLocs.ContainsKey(id))
            {
                if (JumpLocs[id].Type != LocationType.Unknown)
                    return JumpLocs[id];
                else
                    return new JumpLoc(id);
            }
            else
                return new JumpLoc(id);
        }

        public override string ToString()
        {
            return Name;
        }
        
        public static void LoadAll(ProgressBar stations, ProgressBar structures)
        {
            // public structures
            string url = "https://esi.tech.ccp.is/latest/universe/structures/?datasource=tranquility";
            HttpWebRequest web = (HttpWebRequest)WebRequest.CreateHttp(url);
            web.Method = "GET";
            web.ContentLength = 0;


            JArray jarr;
            var response = web.GetResponse();
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                jarr = JArray.Parse(sr.ReadToEnd());
            }

            foreach (JToken tok in jarr)
            {
                JumpLoc.Get(tok.Value<long>());
            }
            JumpLocationsModel.Model.SaveChanges();

            // strucures
            long max = 1030000000000;
            long start = 1021000000000;

            for (long id = start; id <= max; id++)
            {
                JumpLoc.Get(id);
                structures.Value = (int)(100D * (double)(id - start) / (max - start));
            }
            JumpLocationsModel.Model.SaveChanges();

            // stations
            max = 70000000;
            start = 60000000;

            for (long id = start; id <= max; id++)
            {
                JumpLoc.Get(id);
                stations.Value = (int)(100D * (double)(id - start) / (max - start));
            }
            JumpLocationsModel.Model.SaveChanges();
        }
    }

}
