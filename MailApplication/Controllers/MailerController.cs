using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Mvc.Mailer;
using System.Net.Mail;
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
                    var user = db.Users.FirstOrDefault(u => u.UserID == MvcApplication.SessionUser);
                    var ConfigDetails = db.ConfigDetails.FirstOrDefault(u => u.UserID == MvcApplication.SessionUser);

                    if (user != null & ConfigDetails != null)
                    {
                        EmailDetails.SenderName = String.Format("{0} {1}", user.Name, user.LastName);
                        EmailDetails.SenderEmail = user.Email;
                        EmailDetails.RecipientName = Email.RecipientEmail.Substring(0,Email.RecipientEmail.IndexOf("@"));
                        EmailDetails.RecipientEmail = Email.RecipientEmail;
                        EmailDetails.Subject = Email.Subject;
                        EmailDetails.Body = Email.Body;
                        EmailDetails.MailingDate = DateTime.Today;                       
                        EmailDetails.UserID = user.UserID;
                        db.EmailDetails.Add(EmailDetails);
                        db.SaveChanges();

                        using (var clientDetails = new SmtpClient("smtp.gmail.com", 587))
                        {
                            clientDetails.EnableSsl = true;
                            clientDetails.Credentials = new System.Net.NetworkCredential(user.Email, "Woyzeck*2334");
                            clientDetails.EnableSsl = true;                   
                            SmtpClientWrapper wrapper = new SmtpClientWrapper(clientDetails);                       
                            MailApplication.Mailers.IUserMailer mailer = new MailApplication.Mailers.UserMailer();
                            mailer.Welcome(Email.RecipientEmail, Email.Subject, Email.Body).Send(wrapper);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please review your configuration settings");
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


        //public class SmtpClient
        //{
        //    host="smtp.gmail.com" 
        //    port="587" 
       //     userName="diacana5@gmail.com"
       //     password="Woyzeck*2334"
        //}
        /*private MailApplication.Mailers.IUserMailer _mailer = new MailApplication.Mailers.UserMailer();
        public MailApplication.Mailers.IUserMailer Mailer
        {
            get { return _mailer; }
            set { _mailer = value; }
        }*/

    }
}
