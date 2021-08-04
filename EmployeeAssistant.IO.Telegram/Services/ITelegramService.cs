using System.Threading.Tasks;

namespace EmployeeAssistant.IO.Telegram.Services
{
    public interface ITelegramService
    {
        public void Start();
        public Task<long> GetBotId();
    }
}