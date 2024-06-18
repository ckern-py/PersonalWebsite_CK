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

        public GitHubController(ILogger<GitHubController> logger, TelemetryClient telemetryClient)
        {
            _logger = logger;
            this._telemetryClient = telemetryClient;
        }

        public IActionResult Index()
        {
            this._telemetryClient.TrackEvent("GitHubPageRequested");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
