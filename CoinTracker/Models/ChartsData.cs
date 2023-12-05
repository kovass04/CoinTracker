using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CoinTracker.Models
{
    [DataContract]
    public class DataCharts
    {
        [DataMember(Name = "data")]
        public Charts[] Data { get; set; }

        [DataMember(Name = "Timestamp")]
        public long Timestamp { get; set; }
    }

    public class Charts
    {
        [DataMember(Name = "priceUsd")]
        public string PriceUsd { get; set; }

        [DataMember(Name = "time")]
        public long Time { get; set; }

        [DataMember(Name = "data")]
        public DateTime Date { get; set; }
    }
}
