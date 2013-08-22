using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace MailApplication.Models
{
    public class ConfigDetailsModel
    {
       // public int ConfigID { get; set; }  
        [Required(ErrorMessage = "SMTP Host is required")]
        [StringLength(20)]
        [Display(Name = "SMTP Host")]
        public string SMTPHost { get; set; }
        [Required(ErrorMessage = "SMTP Port is required")]
        [Display(Name = "SMTIP Port")]
        public int SMTPPort { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        [StringLength(100, ErrorMessage =
                    "The {0} must be at least {2} " +
                    "characters long", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",
            ErrorMessage = "The password and " +
            "confirmation password do not match")]
        public string PasswordConf { get; set; }
        public string PasswordSalt { get; set; }
        public Guid UserID { get; set; }
        
    }
}