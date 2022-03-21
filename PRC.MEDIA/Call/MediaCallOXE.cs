using Microsoft.Extensions.Configuration;
using PRC.CORE.Media.Call;
using PRC.HELPER.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PRC.MEDIA.Call
{
    public class ProductVersion
    {
        public string major { get; set; }
        public string minor { get; set; }
    }

    public class ServerInfo
    {
        public string productName { get; set; }
        public string productType { get; set; }
        public ProductVersion productVersion { get; set; }
        public bool haMode { get; set; }
    }

    public class Version
    {
        public string id { get; set; }
        public string status { get; set; }
        public string publicUrl { get; set; }
        public string internalUrl { get; set; }
    }

    public class ApiTestResponse
    {
        public ServerInfo serverInfo { get; set; }
        public List<Version> versions { get; set; }
    }
    public class AuthenResponse
    {
        public string credential { get; set; }
        public string publicUrl { get; set; }
        public string internalUrl { get; set; }
    }
    public class Service
    {
        public string serviceName { get; set; }
        public string serviceVersion { get; set; }
        public string relativeUrl { get; set; }
    }

    public class SessionResponse
    {
        public bool admin { get; set; }
        public int timeToLive { get; set; }
        public string publicBaseUrl { get; set; }
        public string privateBaseUrl { get; set; }
        public List<Service> services { get; set; }
    }
    public class CallResponse
    {
        public string httpStatus { get; set; }
        public int code { get; set; }
        public string helpMessage { get; set; }
        public string type { get; set; }
        public string innerMessage { get; set; }
        public bool canRetry { get; set; }
    }

    public class Selector
    {
        public List<string> ids { get; set; }
        public List<string> names { get; set; }
        public List<object> families { get; set; }
        public List<object> origins { get; set; }
    }

    public class Filter
    {
        public List<Selector> selectors { get; set; }
    }

    public class RequestNotication
    {
        public Filter filter { get; set; }
        public string sessionId { get; set; }
        public string version { get; set; }
        public int timeout { get; set; }
        public string webHookUrl { get; set; }
    }
    public class MediaCallOXE : IMediaCall
    {
        private readonly HttpClient _httpClient;
        public MediaCallOXE(IConfiguration Config)
        {
            string URLBase = Config.GetSection("BaseURL").GetSection("URL_OXE_API").Value;

            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, sslErrors) => true
            };

            _httpClient = new HttpClient(handler)
            {
                // BaseAddress = new Uri("http://192.168.0.3:5000/api/"),
                BaseAddress = new Uri(URLBase)
            };
        }

        public async Task<int> MakeCall(string AgentNumber, string CustomNumber)
        {

            var resul = await _httpClient.GetJsonAsync<ApiTestResponse>("");
            if (resul is not null)
            {
                // Anthentification
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes("oxe769:0000")));

                string url = resul.versions[0].internalUrl;
                //var authen = await _httpClient.GetJsonAsync<AuthenResponse>("/authenticate?version=1.0");
                var authen = await _httpClient.GetJsonAsync<AuthenResponse>(url);
                if (authen is not null)
                {
                    // Open cession 
                    url = authen.internalUrl;
                    _httpClient.DefaultRequestHeaders.Add("Cookie", $"AlcUserId={authen.credential}");
                    var session = await _httpClient.PostJsonAsync<SessionResponse>(url, new { applicationName = "TESTS_API" });
                    if (session is not null)
                    {

                        var appel = await _httpClient.PostJsonAsync<CallResponse>("https://192.168.0.36/api/rest/1.0/telephony/basicCall", new { deviceId = "769", callee = "764", autoAnswer = true },report);
                    }

                }


            }

            return 0;
        }

        private void report(HttpResponseMessage obj)
        {
            //throw new NotImplementedException();
        }
    }
}
