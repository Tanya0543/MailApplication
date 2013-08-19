using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace MailApplication.Models
{
    public class ConfigDetailsModel
    {
       // public int ConfigID { get; set; }  
        [Required]
        [Display(Name = "SMTP Host")]
        public string SMTPHost { get; set; }
        [Required]
        [Display(Name = "SMTIP Port")]
        public string SMTPPort { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        public string PasswordConf { get; set; }
        
    }
}