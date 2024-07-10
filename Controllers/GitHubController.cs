using CK_Website_2024.DataLayer;
using CK_Website_2024.Models;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CK_Website_2024.Controllers
{
    public class GitHubController : Controller
    {
        private readonly ILogger<GitHubController> _logger;
        private readonly TelemetryClient _telemetryClient;
        private readonly IWebsiteAPI _websiteAPI;

        public GitHubController(ILogger<GitHubController> logger, TelemetryClient telemetryClient, IWebsiteAPI websiteAPI)
        {
            _logger = logger;
            this._telemetryClient = telemetryClient;
            _websiteAPI = websiteAPI;
        }

        public IActionResult Index()
        {
            this._telemetryClient.TrackEvent("GitHubPageRequested");
            _websiteAPI.LogPageVisit("GitHub");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
