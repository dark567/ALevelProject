using ActionMailer.Net.Mvc;
using LabTestVerThree.Models;

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