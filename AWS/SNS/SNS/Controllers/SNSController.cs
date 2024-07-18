using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace SNS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SNSController : ControllerBase
    {
        private readonly IAmazonSimpleNotificationService _amamzonsns;
        public SNSController(IAmazonSimpleNotificationService amazonsns)
        {
            _amamzonsns = amazonsns;
        }

        [HttpGet]
        public async Task<ActionResult> SendMessageToSNS()
        {
            var request = new PublishRequest
            {
                Message = $"This is from SNS Web api. \n TIME: {DateTime.Now.ToLongDateString()}",
                TopicArn = "arn:aws:sns:us-east-1:891377111621:SNSTopic:28c8b606-d67a-4154-89e8-5c824bbaac31"
            };

            var response = await _amamzonsns.PublishAsync(request);
            return Ok("message sent!");
        }

    }
}
