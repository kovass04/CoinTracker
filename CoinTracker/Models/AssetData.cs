using System.Runtime.Serialization;

namespace CoinTracker.Models
{
    [DataContract]
    public class AssetData
    {
        [DataMember(Name = "data")]
        public Assets[] Data { get; set; }

        [DataMember(Name = "timestamp")]
        public long Timestamp { get; set; }
    }
}
