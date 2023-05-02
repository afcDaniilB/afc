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
using Microsoft.Extensions.Options;
using Telegram.Bots.Types;
using System.Security.Cryptography.X509Certificates;
using Telegram.Bot.Requests;
using System.Net.NetworkInformation;
using System.Reflection;
using System.ComponentModel.Design.Serialization;
using Newtonsoft.Json;
using RestSharp.Serializers;
using System.Text.Json.Serialization;
using Telegram.Bots.Http;

namespace Translator.ExternalServicesClients
{
    public class YandexTranslateService
    {

        //public interface IYandexTranslate
        RestClientOptions options = new RestClientOptions("https://data.binance.com");
        RestClient client;


        public YandexTranslateService()
        {
            client = new RestClient("https://data.binance.com");
        }

        public class ExchangeInformationRequest
        {
            public string endpoint = "/api/v3/exchangeInfo";
            public Method method = Method.Get;
            public object? body;
        }

        public async Task<ExchangeInformationResponse> Send(ExchangeInformationRequest Request)
        {
            var request = new RestRequest(Request.endpoint, Request.method) { RequestFormat = DataFormat.Json };
            //request.AddJsonBody(Request.body);

            var response = await client.ExecuteAsync(request);

            ApiParameters exgResponse = JsonConvert.DeserializeObject<ApiParameters>(Convert.ToString(response.Content));

            return new ExchangeInformationResponse { parameters = exgResponse};
            
        }
        public class ExchangeInformationResponse
        {
            public ApiParameters parameters { get; set; }
        }

        /*
        public RestRequest CreateRequest( string resource, Method method, object? body)
        {
            var request = new RestRequest(resource, method) { RequestFormat = DataFormat.Json };
            request.AddJsonBody(body);
            return request;

        }

        public async Task<RestResponse> GetResponse(RestRequest request)
        {

            var response = await client.ExecuteAsync(request);
            return response;

        }


        public async Task<RestResponse> ExgInfo(string type)
        {
            try
            {
                var request = CreateRequest("/" + type, Method.Get, "");
                var response = await GetResponse(request);
                return response;
                

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public async Task<RestResponse> ExgSymbol(string symbol)
        {
            try
            {
                var request = CreateRequest("/" + symbol, Method.Get, "");
                var response = await GetResponse(request);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        */

        
        public class RateLimit
        {
        }

        public class ApiParameters
        {
            [JsonProperty("timezone")]
            public string Timezone { get; set; }

            [JsonProperty("serverTime")]
            public long ServerTime { get; set; }

            [JsonProperty("rateLimits")]
            public List<RateLimit> RateLimits { get; set; }

            [JsonProperty("exchangeFilters")]
            public List<object> ExchangeFilters { get; set; }

            [JsonProperty("symbols")]
            public List<Symbol> Symbols { get; set; }
        }

        public class Symbol
        {
            [JsonProperty("symbol")]
            public string symbol { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("baseAsset")]
            public string BaseAsset { get; set; }

            [JsonProperty("baseAssetPrecision")]
            public int BaseAssetPrecision { get; set; }

            [JsonProperty("quoteAsset")]
            public string QuoteAsset { get; set; }

            [JsonProperty("quotePrecision")]
            public int QuotePrecision { get; set; }

            [JsonProperty("quoteAssetPrecision")]
            public int QuoteAssetPrecision { get; set; }

            [JsonProperty("orderTypes")]
            public List<string> OrderTypes { get; set; }

            [JsonProperty("icebergAllowed")]
            public bool IcebergAllowed { get; set; }

            [JsonProperty("ocoAllowed")]
            public bool OcoAllowed { get; set; }

            [JsonProperty("quoteOrderQtyMarketAllowed")]
            public bool QuoteOrderQtyMarketAllowed { get; set; }

            [JsonProperty("allowTrailingStop")]
            public bool AllowTrailingStop { get; set; }

            [JsonProperty("cancelReplaceAllowed")]
            public bool CancelReplaceAllowed { get; set; }

            [JsonProperty("isSpotTradingAllowed")]
            public bool IsSpotTradingAllowed { get; set; }

            [JsonProperty("isMarginTradingAllowed")]
            public bool IsMarginTradingAllowed { get; set; }

            [JsonProperty("filters")]
            public List<object> Filters { get; set; }

            [JsonProperty("permissions")]
            public List<string> Permissions { get; set; }

            [JsonProperty("defaultSelfTradePreventionMode")]
            public string DefaultSelfTradePreventionMode { get; set; }

            [JsonProperty("allowedSelfTradePreventionModes")]
            public List<string> AllowedSelfTradePreventionModes { get; set; }
        }




    }


}
