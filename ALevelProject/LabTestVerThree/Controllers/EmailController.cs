using ActionMailer.Net.Mvc;
using LabTestVerThree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTestVerThree.Controllers
{
    public class EmailController : MailerBase
    {
        public EmailResult SendEmail(EmailModel model)
        {
            To.Add(model.To);

            From = model.From;

            Subject = model.Subject;

            return Email("SendEmail", model);
        }
    }
}