using Microsoft.Extensions.Configuration;
using PRC.CORE.Media.Call;
using PRC.HELPER.Extension;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PRC.MEDIA.OXE
{
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
