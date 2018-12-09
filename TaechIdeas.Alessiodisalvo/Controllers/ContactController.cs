using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using TaechIdeas.Alessiodisalvo.Models;

namespace TaechIdeas.Alessiodisalvo.Controllers
{
    public class ContactController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public bool SubmitEmail(string name, string email, string subject, string details)
        {
            try
            {
                var newEmail = new Email
                {
                    From = email,
                    Message = "Da " + name + ": " + details,
                    Subject = subject,
                    To = ConfigurationManager.AppSettings["RecipientEmail"]
                };

                return SendEmail(newEmail);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SendEmail(Email email)
        {
            #region Check Mandatory Fields

            if (String.IsNullOrEmpty(email.From))
                throw new Exception("Field FROM Empty!");
            if (String.IsNullOrEmpty(email.To))
                throw new Exception("Field TO Empty!");

            #endregion

            try
            {
                var clientSmtp = ConfigurationManager.AppSettings["ClientSmtp"];
                var clientSmtpPort = Convert.ToInt32(ConfigurationManager.AppSettings["ClientSmtpPort"]);
                var smtpServerUsn = ConfigurationManager.AppSettings["SmtpServerUsn"];
                var smtpServerPsw = ConfigurationManager.AppSettings["SmtpServerPsw"];

                var mail = new MailMessage();
                var smtpServer = new SmtpClient(clientSmtp, clientSmtpPort);

                // mail.From = new MailAddress(email.From);
                // For Yahoo, alessio.disalvo@yahoo.it must be the mailFrom
                mail.From = new MailAddress(ConfigurationManager.AppSettings["SmtpServerUsn"]);
                mail.To.Add(email.To);
                mail.Subject = email.Subject;


                mail.IsBodyHtml = true;
                mail.Body = $"FROM {email.From}: {email.Message}";

                smtpServer.UseDefaultCredentials = true;
                smtpServer.Credentials = new NetworkCredential(smtpServerUsn, smtpServerPsw);
                smtpServer.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);

                smtpServer.Send(mail);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}