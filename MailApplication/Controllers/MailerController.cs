using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc.Mailer;

namespace MailApplication.Controllers
{
    public class MailerController : Controller
    {
        // GET: /Mailer/
        [HttpGet] 
        public ActionResult Mailer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Mailer(Models.EmailDetailsModel Email)
        {
            if (ModelState.IsValid)
            {
                using (var db = new MailAppDBEntities())
                {
                    var EmailDetails = db.EmailDetails.Create();
                    var user = db.Users.FirstOrDefault(u => u.Email == "diacana5@gmail.com");

                    if (user != null)
                    {
                        EmailDetails.SenderName = String.Format("{0} {1}", user.Name, user.LastName);
                        EmailDetails.SenderEmail = user.Email;
                        EmailDetails.RecipientName = Email.RecipientEmail.Substring(0,Email.RecipientEmail.IndexOf("@"));
                        EmailDetails.RecipientEmail = Email.RecipientEmail;
                        EmailDetails.Subject = Email.Subject;
                        EmailDetails.MailingDate = DateTime.Today;                       
                        EmailDetails.UserID = user.UserID;

                        db.EmailDetails.Add(EmailDetails);
                        db.SaveChanges();

                        MailApplication.Mailers.IUserMailer mailer = new MailApplication.Mailers.UserMailer();
                        mailer.Welcome(Email.RecipientEmail, Email.Subject).Send();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Mail Data is incorrect");
                    }
                        
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Mail Data is incorrect");
            }
            return View();
        }

        /*private MailApplication.Mailers.IUserMailer _mailer = new MailApplication.Mailers.UserMailer();
        public MailApplication.Mailers.IUserMailer Mailer
        {
            get { return _mailer; }
            set { _mailer = value; }
        }*/

    }
}
