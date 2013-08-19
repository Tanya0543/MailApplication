using Mvc.Mailer;

namespace MailApplication.Mailers
{ 
    public class UserMailer : MailerBase, IUserMailer 	
	{
		public UserMailer()
		{
			MasterName="_Layout";
		}
		
		public virtual MvcMailMessage Welcome(string Email, string Subject, string Body)
		{
			var mailMessage = new MvcMailMessage { Subject = Subject };
            mailMessage.To.Add(Email);
            if (string.IsNullOrEmpty(Body) == false)
                mailMessage.Body.Contains(Body);
            return mailMessage;
		}
 
		public virtual MvcMailMessage GoodBye()
		{
			//ViewBag.Data = someObject;
			return Populate(x =>
			{
				x.Subject = "GoodBye";
				x.ViewName = "GoodBye";
				x.To.Add("some-email@example.com");
			});
		}
 	}
}