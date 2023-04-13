using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace SendGridPOC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ISendGridClient _sendGridClient;

        public WeatherForecastController(ISendGridClient sendGridClient)
        {
            _sendGridClient = sendGridClient;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Notify()
        {
            //var msg = new SendGridMessage()
            //{
            //    From = new EmailAddress("savvysavingsapp@gmail.com", "Savvy Savings"),
            //    Subject = "User registration",
            //    TemplateId = "d-fab626068ad44cbba17783d8d42258e2"
            //};

            //msg.AddContent(MimeType.Text, "and easy to do anywhere, even with C#");
            //msg.AddTo(new EmailAddress("ins_sheikh@hotmail.com", "Qasim Sheikh"));

            // https://github.com/sendgrid/sendgrid-csharp
            // https://github.com/sendgrid/sendgrid-csharp/tree/main
            // https://www.twilio.com/blog/send-emails-with-csharp-handlebars-templating-and-dynamic-email-templates

            var from = new EmailAddress("savvysavingsapp@gmail.com", "Savvy Savings");
            var to = new EmailAddress("ins_sheikh@hotmail.com", "Qasim Sheikh");
            var templateId = "d-fab626068ad44cbba17783d8d42258e2";
            var dynamicTemplateData = new
            {
                //subject = $"To-Do List for {DateTime.UtcNow:MMMM}",
                Sender_Name = "Qasim",
                Weblink = "https://www.google.co.uk/",
                email = "abc@abc.com"

            };
            var msg = MailHelper.CreateSingleTemplateEmail(from, to, templateId, dynamicTemplateData);

            var response = await _sendGridClient.SendEmailAsync(msg);

            return Ok(response);
        }
    }
}