using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CK_Website_2024.Models
{
    public class EmailContact
    {     
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a valid email")]
        public string PersonalEmail { get; set; } = string.Empty;
                
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter an email subject")]
        public string EmailSubject { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter an email body")]
        public string EmailMessage { get; set; } = string.Empty;
        public string ActionStatus { get; set; } = string.Empty;
        public bool SubmitSuccessful { get; set; } = false;
    }
}
