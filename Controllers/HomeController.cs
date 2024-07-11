using CK_Website_2024.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.ApplicationInsights;
using CK_Website_2024.DataLayer;

namespace CK_Website_2024.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TelemetryClient _telemetryClient;
        private readonly IWebsiteAPI _websiteAPI;

        public HomeController(ILogger<HomeController> logger, TelemetryClient telemetryClient, IWebsiteAPI websiteAPI)
        {
            _logger = logger;
            this._telemetryClient = telemetryClient;
            _websiteAPI = websiteAPI;
        }

        public IActionResult Index()
        {
            this._telemetryClient.TrackEvent("HomePageRequested");
            Task.Run(() => _websiteAPI.LogPageVisit("Home"));
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
