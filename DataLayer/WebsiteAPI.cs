using CK_Website_2024.Models.API_Models;
using System.Text;
using Newtonsoft.Json;

namespace CK_Website_2024.DataLayer
{
    public class WebsiteAPI : IWebsiteAPI
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public WebsiteAPI(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public void LogPageVisit(string pageName)
        {
            InsertPageVisitRequest request = new InsertPageVisitRequest()
            {
                PageName = pageName,
                RequestingSystem = _configuration["REQUESTING_SYSTEM"]
            };

            HttpContent body = new StringContent(JsonConvert.SerializeObject(request), Encoding.Default, "application/json");

            _httpClient.PostAsync("PageVisit/InsertPageVisit", body);
        }
    }
}
