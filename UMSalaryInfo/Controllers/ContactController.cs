using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace UMSalaryInfo.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string SendMail(string name, string fromEmail, string message)
        {
            var mailMessage = new System.Net.Mail.MailMessage();
            fromEmail = "shray.7@gmail.com";
            string fromPW = "royalred714";
            string toEmail = "shray.7@gmail.com";
            mailMessage.From = new MailAddress(fromEmail);
            mailMessage.To.Add(toEmail);
            mailMessage.Subject = "Hello from "+ name;
            mailMessage.Body = message;
            mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(fromEmail, fromPW);

                smtpClient.Send(mailMessage.From.ToString(), mailMessage.To.ToString(),
                                mailMessage.Subject, mailMessage.Body);
            }
            return null;
        }
    }
}