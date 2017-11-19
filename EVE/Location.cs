using Newtonsoft.Json.Linq;
using SDEModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EVE
{
    public enum LocationType { Citadel, Station, Unknown }
    public class Location
    {
        public static readonly Dictionary<long, Location> KnownLocations = new Dictionary<long, Location>();

        public long ID;
        public string Name;
        public LocationType Type;

        public mapSolarSystem System;
        public invType StructureType;

        private Location(long id)
        {
            ID = id;
            System = null;
            StructureType = null;
            Type = LocationType.Unknown;
            Name = "Unknown";

            foreach(Character c in Character.KnownCharacters.Values)
            {
                JObject jobj;

                try
                {
                    string url = "https://esi.tech.ccp.is/latest/universe/structures/" + ID + "/?datasource=tranquility&token=" + c.AuthToken;
                    HttpWebRequest web = (HttpWebRequest)WebRequest.CreateHttp(url);
                    web.Method = "GET";
                    web.ContentLength = 0;

                    var response = web.GetResponse();
                    using (var sr = new StreamReader(response.GetResponseStream()))
                    {
                        jobj = JObject.Parse(sr.ReadToEnd());
                    }
                } catch (Exception e)
                {
                    continue;
                }

                if (jobj["error"] == null)
                    continue;

                Name = (string)jobj["name"];
                StructureType = SDEEntities.SDE.GetTypeFromID((int)jobj["type_id"]).First();
                System = SDEEntities.SDE.GetSystemFromID((int)jobj["solar_system_id"]).First();
                Type = LocationType.Citadel;
                break;
            }

            if(Type == LocationType.Unknown)    // didn't find it looking at structures, look at stations
            {
                foreach (Character c in Character.KnownCharacters.Values)
                {
                    JObject jobj;

                    try
                    {
                        string url = "https://esi.tech.ccp.is/latest/universe/stations/" + ID + "/?datasource=tranquility&token=" + c.AuthToken;
                        HttpWebRequest web = (HttpWebRequest)WebRequest.CreateHttp(url);
                        web.Method = "GET";
                        web.ContentLength = 0;

                        var response = web.GetResponse();
                        using (var sr = new StreamReader(response.GetResponseStream()))
                        {
                            jobj = JObject.Parse(sr.ReadToEnd());
                        }
                    }
                    catch (Exception e)
                    {
                        continue;
                    }

                    if (jobj["error"] == null)
                        continue;

                    Name = (string)jobj["name"];
                    StructureType = SDEEntities.SDE.GetTypeFromID((int)jobj["type_id"]).First();
                    System = SDEEntities.SDE.GetSystemFromID((int)jobj["system_id"]).First();
                    Type = LocationType.Station;
                    break;
                }
            }

            if(this.Type != LocationType.Unknown)
                KnownLocations.Add(id, this);
        }

        private static long maxID = 0;
        public static Location Get(long id)
        {
            if (id > maxID)
                maxID = id;

            if (KnownLocations.ContainsKey(id))
            {
                if(KnownLocations[id].Type != LocationType.Unknown)
                    return KnownLocations[id];
                else
                    return new Location(id);
            }
            else
                return new Location(id);
        }

        public override string ToString()
        {
            return Name;
        }

    }

    

}
