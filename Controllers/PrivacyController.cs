using CK_Website_2024.Models;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CK_Website_2024.Controllers
{
    public class PrivacyController : Controller
    {
        private readonly ILogger<PrivacyController> _logger;
        private readonly TelemetryClient _telemetryClient;

        public PrivacyController(ILogger<PrivacyController> logger, TelemetryClient telemetryClient)
        {
            _logger = logger;
            this._telemetryClient = telemetryClient;
        }

        public IActionResult Index()
        {
            this._telemetryClient.TrackEvent("PrivacyPageRequested");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}