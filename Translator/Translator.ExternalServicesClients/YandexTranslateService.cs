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

namespace Translator.ExternalServicesClients
{
    public class YandexTranslateService
    {

        //public interface IYandexTranslate
        RestClientOptions options = new RestClientOptions("https://yandextranslatezakutynskyv1.p.rapidapi.com");
        RestClient client = new RestClient();


       public YandexTranslateService()
       {
           client = new RestClient();
       }
         

        public RestRequest CreateRequest(string resource, Method method, object? body)
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
        public async Task<RestResponse>  GetLangs()
        {

                var request = CreateRequest("/language");
                var response = await GetResponse(request);
                return response;

        }
        public async Task<RestResponse> Translate(string text, string lang)
        {
            var request = CreateRequest("");
            var response = await GetResponse(request);
            return response;
        }
    }
}
