using System;
using System.Net;
using System.Net.Mail;
using DockerTraining.Web.Models;

namespace DockerTraining.Web.Infrastructure
{
    public class EmailSender
    {
        public static void Send(SmtpServerSettings smtpServerSettings, EmailMessage emailMessage)
        {
            var host = Environment.GetEnvironmentVariable("dockerMailHost");
            if (string.IsNullOrEmpty(host))
                host = "localhost";
            using (var client = new SmtpClient(host))
            {
                //client.EnableSsl = true;
                client.Port = 25;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //client.UseDefaultCredentials = false;
                //client.Credentials = new NetworkCredential(smtpServerSettings.UserName, smtpServerSettings.Password);

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(smtpServerSettings.UserName),
                    Body = emailMessage.Body,
                    Subject = emailMessage.Subject
                };

                mailMessage.To.Add(emailMessage.To);
                client.Send(mailMessage);
            }
        }
    }
}
