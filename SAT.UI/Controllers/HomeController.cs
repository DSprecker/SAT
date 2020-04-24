using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using SAT.UI.Models;
using System;

namespace SAT.UI.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                string body = $"{cvm.Name} has sent you the following message: <br />" +
                    $"{cvm.Message} <strong>from the email address:</strong> {cvm.Email}";

                MailMessage m = new MailMessage("you@yourDomain.com", "ToYourPersonalEmail.com", cvm.Subject, body);

                m.IsBodyHtml = true;

                m.Priority = MailPriority.High;

                m.ReplyToList.Add(cvm.Email);

                SmtpClient client = new SmtpClient("mail.yourDomain.ext");

                client.Credentials = new NetworkCredential("YourEmailUserName = Web Host", "Your Email Password - Webhost");

                try
                {
                    client.Send(m);
                }
                catch (Exception e)
                {

                    ViewBag.Message = e.StackTrace;
                }
                return View("ContactConfirmation");
            }

            return View(cvm);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Students()
        {
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "Admin, Scheduling")]
        public ActionResult Enrollments()
        {
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Courses()
        {
            return View();
        }
          
    
    }
}
