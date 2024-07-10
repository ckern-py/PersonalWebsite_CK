namespace CK_Website_2024.DataLayer
{
    public class WebsiteAPI : IWebsiteAPI
    {
        private readonly IConfiguration _configuration;
        public WebsiteAPI(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void LogPageVisit(string pageName)
        {

        }
    }
}
