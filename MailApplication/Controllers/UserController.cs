using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace MailApplication.Controllers
{
    public class UserController : Controller
    {
        // GET: /Login/

        [HttpGet] 
        public ActionResult LogIn()
        {
            return View();
        }

        // POST: /Login/
        [HttpPost] 
        public ActionResult LogIn(Models.UserModel user)
        {
            if(ModelState.IsValid)
            {
                if (IsValid(user.Email, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect Login Data");
                }
            }

            return View(user);
        }

        // GET: /Register/
        [HttpGet]
        public ActionResult RegisterUser()
        {
            return View();
        }

        // POST: /Register/
        [HttpPost] //After the user enters the information 
        public ActionResult RegisterUser(Models.UserModel user)
        {
            if (ModelState.IsValid)
            {
                using (var db = new MailAppDBEntities())
                {
                    var Crypto = new SimpleCrypto.PBKDF2();
                    var encPass = Crypto.Compute(user.Password);
                    var SysUser = db.Users.Create();
                    
                    SysUser.Email = user.Email;
                    SysUser.Password = encPass; 
                    SysUser.PasswordSalt = Crypto.Salt;
                    SysUser.UserID = Guid.NewGuid();
                    SysUser.Name = user.Name;
                    SysUser.LastName = user.LastName;
                    SysUser.Genre = user.Genre;
                    SysUser.BirthDay = user.BirthDay;
                    
                    db.Users.Add(SysUser); 
                    db.SaveChanges(); 
                        
                    return RedirectToAction("Index","Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Login Data is incorrect");
            }
            return View();
        }

        private bool IsValid(string email, string password)
        {
            var Crypto = new SimpleCrypto.PBKDF2(); //instantiate the SimpleCrypto Class to be able to encrypt the password
            bool isValid =false;
            
            using (var db = new MailAppDBEntities())
            {
                var user = db.Users.FirstOrDefault(u=>u.Email == email);
                if (user != null)
                {
                    if(user.Password== Crypto.Compute(password,user.PasswordSalt))
                    {
                        isValid = true;
                    }
                }
            }

            return isValid;
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }

        // GET: /MailConfig/
        [HttpGet]
        public ActionResult MailConfig()
        {
            return View();
        }

        // POST: /MailConfig/
        [HttpPost]
        public ActionResult MailConfig(Models.ConfigDetailsModel MailConfig)
        {
            if (ModelState.IsValid)
            {
                using (var db = new MailAppDBEntities())
                {
                    var ConfigDetails = db.ConfigDetails.Create();
                    var Crypto = new SimpleCrypto.PBKDF2();
                    var encPass = Crypto.Compute(MailConfig.Password);
                    var user = db.Users.FirstOrDefault(u => u.Email == "diacana5@gmail.com");

                    ConfigDetails.SMTPHost = MailConfig.SMTPHost;
                    ConfigDetails.SMTPPort = MailConfig.SMTPPort;
                    ConfigDetails.Password = encPass;
                    ConfigDetails.PasswordSalt = Crypto.Salt;
                    ConfigDetails.UserID = user.UserID;

                    db.ConfigDetails.Add(ConfigDetails);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Login Data is incorrect");
            }
            return View();
        }

    }


    namespace Kendo.Mvc.Examples.Controllers
    {
        using System.Web.Mvc;

        public partial class AutoCompleteController : Controller
        {
            public ActionResult Index()
            {
                return View();
            }
        }
    }

}
