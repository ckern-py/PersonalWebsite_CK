using CK_Website_2024.Models.API_Models;
using System.Text;
using Newtonsoft.Json;
using CK_Website_2024.Models;
using System.Text.Json;

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

        public List<GitHubProjects> GetGitHubProjects()
        {
            string responseData = string.Empty;
            List<GitHubProjects> gitHubList = null;

            BaseRequest request = new BaseRequest()
            {
                RequestingSystem = _configuration["REQUESTING_SYSTEM"]
            };

            HttpContent body = new StringContent(JsonConvert.SerializeObject(request), Encoding.Default, "application/json");

            HttpResponseMessage response = _httpClient.PostAsync("GitHub/GetGitHubProjects", body).GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode)
            {
                GitHubProjectsResponse projectsResponse = JsonConvert.DeserializeObject<GitHubProjectsResponse>(response.Content.ReadAsStringAsync().Result);
                gitHubList = projectsResponse.GitHubProjects;
            }

            return gitHubList;
        }
    }
}
