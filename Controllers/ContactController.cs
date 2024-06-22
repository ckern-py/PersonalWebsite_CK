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
            EmailContact emailContactFields = new EmailContact();
            this._telemetryClient.TrackEvent("ContactPageRequested");
            return View(emailContactFields);
        }

        [HttpPost]
        public IActionResult Index(EmailContact emailContact)
        {
            if (ModelState.IsValid)
            {
                string telemetryEmail = $"UserContactEmail:\nEmail: {emailContact.PersonalEmail}\nSubject: {emailContact.EmailSubject}\nMessage: {emailContact.EmailMessage}";
                this._telemetryClient.TrackEvent(telemetryEmail);
                this._telemetryClient.TrackEvent("ContactPageEmailSent");
                ModelState.Clear();
                emailContact = new EmailContact()
                {
                    SubmitSuccessful = true,
                    ActionStatus = "Your email as been sent"
                };
            }
            return View(emailContact);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
