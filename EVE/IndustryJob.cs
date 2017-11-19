

using Newtonsoft.Json;
using SDEModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace EVE
{
    public enum IndustryJobStatus {Active, Completed};
    public enum IndustryJobType
    {
        [Description("Production")]
        Production =1,
        [Description("T3 Research???")]
        T3Research,
        [Description("TE Research")]
        TEResearch,
        [Description("ME Research")]
        MEResearch,
        [Description("Copying")]
        Copying,
        [Description("Duplicating")]
        Duplicating,
        [Description("Reverse Engineering")]
        ReverseEngineering,
        [Description("Invention")]
        Invention,
        [Description("Reaction")]
        Reaction =11
    }
    public class IndustryJob
    {
        [JsonProperty("job_id")]
        public int JobID;

        [JsonProperty("installer_id")]
        public int InstallerID;

        [JsonProperty("facility_id")]
        public int FacilityID;

        [JsonIgnore]
        public Location Facility;

        [JsonProperty("station_id")]
        public int StationID;

        [JsonProperty("activity_id")]
        public int ActivityID;

        [JsonIgnore]
        public IndustryJobType ActivityType {get=> (IndustryJobType) ActivityID; }

        [JsonProperty("blueprint_type_id")]
        public int BlueprintTypeID;

        [JsonIgnore]
        public industryActivity BlueprintActivity;

        [JsonIgnore]
        public invType ProductType;

        [JsonProperty("output_location_id")]
        public int OutputLocationID;

        [JsonProperty("runs")]
        public int Runs;

        [JsonProperty("cost")]
        public int Cost;


        [JsonProperty("status")]
        [JsonConverter(typeof(StatusConverter))]
        public IndustryJobStatus Status;

        [JsonProperty("duration")]
        public int Duration;

        [JsonProperty("start_date")]
        public DateTime StartDate;

        [JsonProperty("end_date")]
        public DateTime EndDate;

        [OnDeserialized]
        internal void postDeseralize(StreamingContext context)
        {
            BlueprintActivity = SDEEntities.SDE.GetBlueprintActivity(BlueprintTypeID, ActivityID).First();
            ProductType = SDEEntities.SDE.GetBlueprintProducts(BlueprintTypeID, ActivityID).First().productType;
            Facility = Location.Get(FacilityID);
        }

        internal class StatusConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(string);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                string status = (string)existingValue;
                switch (status)
                {
                    case "active":
                        return IndustryJobStatus.Active;
                    default:
                        return IndustryJobStatus.Completed;
                }
            }

            public override bool CanWrite => false;

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }

    }
}
