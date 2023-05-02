using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using System.Threading;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Translator.ApplicationEntities
{
    public class TranslatorEntities
    {
        //Root myDeserializedClass = JsonConvert.DeserializeObject<Root>();
        public class RateLimit
        {
        }

        public class Root
        {
            [JsonProperty("timezone")]
            [JsonPropertyName("timezone")]
            public string timezone { get; set; }

            [JsonProperty("serverTime")]
            [JsonPropertyName("serverTime")]
            public long serverTime { get; set; }

            [JsonProperty("rateLimits")]
            [JsonPropertyName("rateLimits")]
            public List<RateLimit> rateLimits { get; set; }

            [JsonProperty("exchangeFilters")]
            [JsonPropertyName("exchangeFilters")]
            public List<object> exchangeFilters { get; set; }

            [JsonProperty("symbols")]
            [JsonPropertyName("symbols")]
            public List<Symbol> symbols { get; set; }
        }

        public class Symbol
        {
            [JsonProperty("symbol")]
            [JsonPropertyName("symbol")]
            public string symbol { get; set; }

            [JsonProperty("status")]
            [JsonPropertyName("status")]
            public string status { get; set; }

            [JsonProperty("baseAsset")]
            [JsonPropertyName("baseAsset")]
            public string baseAsset { get; set; }

            [JsonProperty("baseAssetPrecision")]
            [JsonPropertyName("baseAssetPrecision")]
            public int baseAssetPrecision { get; set; }

            [JsonProperty("quoteAsset")]
            [JsonPropertyName("quoteAsset")]
            public string quoteAsset { get; set; }

            [JsonProperty("quotePrecision")]
            [JsonPropertyName("quotePrecision")]
            public int quotePrecision { get; set; }

            [JsonProperty("quoteAssetPrecision")]
            [JsonPropertyName("quoteAssetPrecision")]
            public int quoteAssetPrecision { get; set; }

            [JsonProperty("orderTypes")]
            [JsonPropertyName("orderTypes")]
            public List<string> orderTypes { get; set; }

            [JsonProperty("icebergAllowed")]
            [JsonPropertyName("icebergAllowed")]
            public bool icebergAllowed { get; set; }

            [JsonProperty("ocoAllowed")]
            [JsonPropertyName("ocoAllowed")]
            public bool ocoAllowed { get; set; }

            [JsonProperty("quoteOrderQtyMarketAllowed")]
            [JsonPropertyName("quoteOrderQtyMarketAllowed")]
            public bool quoteOrderQtyMarketAllowed { get; set; }

            [JsonProperty("allowTrailingStop")]
            [JsonPropertyName("allowTrailingStop")]
            public bool allowTrailingStop { get; set; }

            [JsonProperty("cancelReplaceAllowed")]
            [JsonPropertyName("cancelReplaceAllowed")]
            public bool cancelReplaceAllowed { get; set; }

            [JsonProperty("isSpotTradingAllowed")]
            [JsonPropertyName("isSpotTradingAllowed")]
            public bool isSpotTradingAllowed { get; set; }

            [JsonProperty("isMarginTradingAllowed")]
            [JsonPropertyName("isMarginTradingAllowed")]
            public bool isMarginTradingAllowed { get; set; }

            [JsonProperty("filters")]
            [JsonPropertyName("filters")]
            public List<object> filters { get; set; }

            [JsonProperty("permissions")]
            [JsonPropertyName("permissions")]
            public List<string> permissions { get; set; }

            [JsonProperty("defaultSelfTradePreventionMode")]
            [JsonPropertyName("defaultSelfTradePreventionMode")]
            public string defaultSelfTradePreventionMode { get; set; }

            [JsonProperty("allowedSelfTradePreventionModes")]
            [JsonPropertyName("allowedSelfTradePreventionModes")]
            public List<string> allowedSelfTradePreventionModes { get; set; }
        }


    }
}

