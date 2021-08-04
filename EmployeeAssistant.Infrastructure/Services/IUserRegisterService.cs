using System.Threading.Tasks;

namespace EmployeeAssistant.Infrastructure.Services
{
    public interface IUserRegisterService
    {
        public Task<bool> Register(string email, string password, string name);
    }
}