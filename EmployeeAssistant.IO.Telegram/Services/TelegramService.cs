using System.Threading.Tasks;
using EmployeeAssistant.IO.Telegram.Handlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Telegram.Bot;

namespace EmployeeAssistant.IO.Telegram.Services
{
    public class TelegramService : ITelegramService
    {
        private readonly ITelegramBotClient _client;
        private readonly ILogger<TelegramService> _logger;

        public TelegramService(ILogger<TelegramService> logger, IConfiguration configuration)
        {
            var apiKey = configuration["TelegramToken"];
            
            _client = new TelegramBotClient(apiKey);
            _logger = logger;
        }

        public void Start()
        {
            _logger.LogInformation("Telegram bot started to receive messages");
            _client.StartReceiving<TelegramHandler>();
        }

        public async Task<long> GetBotId()
        {
            var me = await _client.GetMeAsync();

            return me.Id;
        }
    }
}