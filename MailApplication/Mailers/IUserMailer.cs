using Mvc.Mailer;

namespace MailApplication.Mailers
{ 
    public interface IUserMailer
    {
        MvcMailMessage Welcome(string Email, string Subject, string Body);
		MvcMailMessage GoodBye();
	}
}