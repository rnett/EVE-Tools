using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EVE
{
    public enum ContractType {
        [Description("Courier")]
        Courier,
        [Description("Item Exchange")]
        ItemExchange,
        [Description("Auction")]
        Auction }
    public enum ContractStatus
    {
        [Description("Outstanding")]
        Outstanding,
        [Description("In Progress")]
        InProgress,
        [Description("Completed")]
        Completed
    }

    public class Contract
    {
        [JsonProperty("contract_id")]
        public long ContractID;

        [JsonProperty("issuer_id")]
        public long IssuerID;

        [JsonProperty("issuer_corporation_id")]
        public long IssuerCorporationID;
        
        [JsonProperty("assignee_id")]
        public long AssigneeID;
        
        [JsonProperty("acceptor_id")]
        public long AcceptorID;

        [JsonProperty("type")]
        [JsonConverter(typeof(TypeConverter))]
        public ContractType Type;

        [JsonProperty("status")]
        [JsonConverter(typeof(StatusConverter))]
        public ContractStatus Status;

        [JsonProperty("for_corporation")]
        public bool ForCorporation;

        [JsonProperty("date_issued")]
        public DateTime DateIssued;

        [JsonProperty("date_expired")]
        public DateTime DateExpired;

        [JsonProperty("start_location_id")]
        public long StartLocationID;

        [JsonIgnore]
        public Location StartLocation { get => Location.Get(StartLocationID); }

        [JsonProperty("end_location_id")]
        public long EndLocationID;

        [JsonIgnore]
        public Location EndLocation { get => Location.Get(EndLocationID); }

        [JsonProperty("date_accepted")]
        public DateTime DateAccepted;

        [JsonProperty("date_completed")]
        public DateTime DateCompleted;

        [JsonProperty("days_to_complete")]
        public int DaysToComplete;

        [JsonProperty("price")]
        public int Price;

        [JsonProperty("collateral")]
        public int Collateral;

        [JsonProperty("reward")]
        public int Reward;

        [JsonProperty("volume")]
        public int Volume;

        public override string ToString()
        {
            return Status.GetDescription() + " " + Type.GetDescription() + " contract";
        }

        internal class StatusConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(string);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                string status = (string)reader.Value;
                switch (status)
                {
                    case "outstanding":
                        return ContractStatus.Outstanding;
                    case "in_progress":
                        return ContractStatus.InProgress;
                    default:
                        return ContractStatus.Completed;
                }
            }

            public override bool CanWrite => false;

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
        internal class TypeConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(string);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                string status = (string)reader.Value;
                switch (status)
                {
                    case "auction":
                        return ContractType.Auction;
                    case "courier":
                        return ContractType.Courier;
                    default:
                        return ContractType.ItemExchange;
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
