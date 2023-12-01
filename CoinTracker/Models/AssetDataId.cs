using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CoinTracker.Models
{
    [DataContract]
    public class AssetDataId
    {
        [DataMember(Name = "data")]
        public Assets Data { get; set; }

        [DataMember(Name = "timestamp")]
        public long Timestamp { get; set; }
    }
}
