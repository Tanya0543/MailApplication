//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MailApplication
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmailDetail
    {
        public int EmailID { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string RecipientName { get; set; }
        public string RecipientEmail { get; set; }
        public string Subject { get; set; }
        public System.DateTime MailingDate { get; set; }
        public System.Guid UserID { get; set; }
    
        public virtual User User { get; set; }
    }
}
