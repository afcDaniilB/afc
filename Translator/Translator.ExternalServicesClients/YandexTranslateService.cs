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

namespace Translator.ExternalServicesClients
{
    public class YandexTranslateService
    {

        //public interface IYandexTranslate
        RestClientOptions options = new RestClientOptions("https://translate.yandex.net/api/v1.5/tr.json");
        RestClient client = new RestClient();


        public YandexTranslateService()
        {
            client = new RestClient(options);
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
        public async Task<RestResponse>  GetLangs(string type)
        {
            try
            {
                string apikey = "t1.9euelZqPiZ2XlYmajJvKnJDPmsydnu3rnpWax5zKkMbNzZHLyJmTz86cks7l9PcMHl1d-e8zdVGG3fT3TExaXfnvM3VRhg.t1M7kp9BEdQh-ggyn-vjChvMCuJ15KDXC4Al9Qi2kNm2X1Pc_x59mXk51kKAK0_tzJB_yvNO3BQIKG-OzSbpBg";
                var request = CreateRequest("/getLangs?ui=" + type + "&key="+apikey, Method.Post, "");
                var response = await GetResponse(request);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RestResponse> Translate(string text, string lang)
        {
            string apikey = "t1.9euelZrLmYnOjcaJl4mNmpmXlpPLme3rnpWax5zKkMbNzZHLyJmTz86cks7l8_cfLl1d-e9TXA4x_d3z919cWl3571NcDjH9.Bf4WL2MHsSSjMcnDTVQ0uEMRde4NW5-UEmhD2Jk3T4Grv4U7BijbjYF6BHJY4DkyCeAolvj-yb9Sif_6DgWwBw";
            var request = CreateRequest("/translate?key="+ apikey + "&text=" + text + "&lang="+lang, Method.Get, null);
            var response = await GetResponse(request);
            return response;
        }
    }
}
