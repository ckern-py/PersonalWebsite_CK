using CK_Website_2024.DataLayer;
using CK_Website_2024.Models;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CK_Website_2024.Controllers
{
    public class NotFoundController : Controller
    {
        private readonly ILogger<NotFoundController> _logger;
        private readonly TelemetryClient _telemetryClient;
        private readonly IWebsiteAPI _websiteAPI;

        public NotFoundController(ILogger<NotFoundController> logger, TelemetryClient telemetryClient, IWebsiteAPI websiteAPI)
        {
            _logger = logger;
            this._telemetryClient = telemetryClient;
            this._websiteAPI = websiteAPI;
        }

        public IActionResult Index()
        {
            this._telemetryClient.TrackEvent("NotFoundPageRequested");
            Task.Run(() => _websiteAPI.LogPageVisit("NotFound"));
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
