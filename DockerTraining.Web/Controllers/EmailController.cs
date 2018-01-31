using DockerTraining.Web.Infrastructure;
using DockerTraining.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DockerTraining.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Email")]
    public class EmailController : Controller
    {
        private readonly IOptions<SmtpServerSettings> _smtpServerSettings;

        public EmailController(IOptions<SmtpServerSettings> smtpServerSettings)
        {
            _smtpServerSettings = smtpServerSettings;
        }

        // POST: api/Email
        [HttpPost]
        public void Post([FromBody]EmailMessage emailMessage)
        {
            EmailSender.Send(_smtpServerSettings.Value, emailMessage);
        }
    }
}