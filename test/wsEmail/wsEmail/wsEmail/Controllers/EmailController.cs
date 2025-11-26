using Microsoft.AspNetCore.Mvc;
using wsEmail.Services;

namespace wsEmail.Controllers
{
    [Route("api/Emails")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService) {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(string to, string subject, string body)
        {
            await _emailService.SendEmail(to, subject, body);
            return Ok();
        }
    }
}
