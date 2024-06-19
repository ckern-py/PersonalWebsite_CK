using CK_Website_2024.Models;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CK_Website_2024.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        private readonly TelemetryClient _telemetryClient;

        public ContactController(ILogger<ContactController> logger, TelemetryClient telemetryClient)
        {
            _logger = logger;
            this._telemetryClient = telemetryClient;
        }

        [HttpGet]
        public IActionResult Index()
        {
            this._telemetryClient.TrackEvent("ContactPageRequested");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendEmail(EmailContact emailContact)
        {
            if (!ModelState.IsValid)
                return View("Error", ModelState.Values.SelectMany(v => v.Errors));

            // _submitStatus = "Your email has been sent";
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
