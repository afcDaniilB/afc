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
         

        public RestRequest CreateRequest(string resource, Method method, object? body)
        {
            var request = new RestRequest(resource, method) { RequestFormat = DataFormat.Json };
            request.AddJsonBody(body);
            return request;

        }

        public async Task<RestResponse> GetResponse(RestRequest request)
        {
            try
            {
                var response = await client.ExecuteAsync(request);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        public async Task<RestResponse>  ExgInfo(string type)
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
    }
}
