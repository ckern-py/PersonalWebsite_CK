using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CK_Website_2024.Models
{
    public class EmailContact
    {
        [BindProperty]
        [Required(AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public required string PersonalEmail { get; set; }

        [BindProperty]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter an email subject")]
        public required string EmailSubject { get; set; }

        [BindProperty]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter an email body")]
        public required string EmailMessage { get; set; }

    }
}
