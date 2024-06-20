using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CK_Website_2024.Models
{
    public class EmailContact
    {     
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a valid email")]
        public required string PersonalEmail { get; set; }
                
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter an email subject")]
        public required string EmailSubject { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter an email body")]
        public required string EmailMessage { get; set; }

    }
}
