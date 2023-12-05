﻿using System.Runtime.Serialization;

namespace CoinTracker.Models
{
    [DataContract]
    public class Assets
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "rank")]
        public int Rank { get; set; }

        [DataMember(Name = "symbol")]
        public string Symbol { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "supply")]
        public string Supply { get; set; }

        [DataMember(Name = "maxSupply")]
        public string MaxSupply { get; set; }

        [DataMember(Name = "marketCapUsd")]
        public string MarketCapUsd { get; set; }

        [DataMember(Name = "volumeUsd24Hr")]
        public string VolumeUsd24Hr { get; set; }

        [DataMember(Name = "priceUsd")]
        public decimal PriceUsd { get; set; }

        [DataMember(Name = "changePercent24Hr")]
        public string ChangePercent24Hr { get; set; }

        [DataMember(Name = "vwap24Hr")]
        public string Vwap24Hr { get; set; }

        [DataMember(Name = "explorer")]
        public string Explorer { get; set; }
    }
}
