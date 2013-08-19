using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MailApplication.Models
{
    public class EmailDetailsModel
    {
        [Required]
        [Display(Name = "To")]
    public string RecipientEmail { get; set; }
        
        [Display(Name = "Subject")]
    public string Subject { get; set; }

    public string Body { get; set; } 
    }
}