using CK_Website_2024.Models;
using CK_Website_2024.Models.API_Models;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Text;

namespace CK_Website_2024.DataLayer
{
    public class WebsiteAPI : IWebsiteAPI
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        readonly IMemoryCache _cache;

        private List<GitHubProjects> projects = null!;

        public WebsiteAPI(IConfiguration configuration, HttpClient httpClient, IMemoryCache cache)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _cache = cache;
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

            if (_cache.TryGetValue("GitHubProjects", out projects))
            {
                gitHubList = projects;
            }
            else
            {
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

                MemoryCacheEntryOptions cacheEntryOptions = new MemoryCacheEntryOptions();
                cacheEntryOptions.SetSlidingExpiration(TimeSpan.FromHours(6));
                cacheEntryOptions.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(24);
                _cache.Set("GitHubProjects", gitHubList, cacheEntryOptions);
            }

            return gitHubList;
        }
    }
}
