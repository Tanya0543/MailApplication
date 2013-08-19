using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MailApplication.Models
{
    public class UserModel
    {
        //[Required]
    //public String UserID{ get; set; } 
       // [Required]
    public string Name{ get; set; }
        [Display(Name = "Last Name")]
    public string LastName{ get; set; }    
        [Display(Name = "Birthday")]
    public DateTime BirthDay{ get; set; } 
    public string Genre{ get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(20)]
        [Display(Name = "Password")]
    public string Password { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(50)]
        [Display(Name = "Email Address")]
    public string Email { get; set; }
    }
}