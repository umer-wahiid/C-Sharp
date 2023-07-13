using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace ConsoleApp1
{
    class Mail
    {
        public void EMail(Exception ex)
        {
            // Catch the error and extract details
            string errorMessage = ex.Message;
            string stackTrace = ex.StackTrace;

            // Configure email message
            string recipientEmail = "umerwahiid48@gmail.com";
            string subject = "Error Email";
            string body = $"An error occurred:\n\n{errorMessage}\n\nStack Trace:\n{stackTrace}";

            // Configure SMTP client
            SmtpClient smtpClient = new SmtpClient("sandbox.smtp.mailtrap.io", 2525);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = new NetworkCredential("1b81aa011afdf6", "672b6fc6846266");

            // Create and send the email
            MailMessage mailMessage = new MailMessage("imranahmedshoppc@gmail.com", recipientEmail, subject, body);
            smtpClient.Send(mailMessage);
        }
 
    }
}
