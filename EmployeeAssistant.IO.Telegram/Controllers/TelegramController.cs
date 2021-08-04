using System.Threading.Tasks;
using EmployeeAssistant.IO.Telegram.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeAssistant.IO.Telegram.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TelegramController : ControllerBase
    {
        private readonly ILogger<TelegramController> _logger;
        private readonly ITelegramService _telegram;
        
        public TelegramController(ILogger<TelegramController> logger, ITelegramService telegramService)
        {
            _logger = logger;
            _telegram = telegramService;
        }

        [HttpGet("/startBot")]
        public void StartTelegramBot()
        {
            _logger.LogInformation("Telegram Bot Initialization..");
            _telegram.Start();
        }

        [HttpGet("/getBotId")]
        public async Task<long> GetBotId()
        {
            var id = await _telegram.GetBotId();

            return id;
        }
    }
}