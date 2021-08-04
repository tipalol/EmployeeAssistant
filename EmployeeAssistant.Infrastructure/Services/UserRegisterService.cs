using System;
using System.Threading.Tasks;
using EmployeeAssistant.Core.Factories;
using EmployeeAssistant.Infrastructure.Repositories;
using Serilog;

namespace EmployeeAssistant.Infrastructure.Services
{
    public class UserRegisterService : IUserRegisterService
    {
        private IUserRepository _userRepository;
        //private readonly ILogger _logger;
        
        public UserRegisterService(IUserRepository repository)//, ILogger logger)
        {
            _userRepository = repository;
            //_logger = logger;
        }
        
        public async Task<bool> Register(string email, string password, string name)
        {
            var user = await UserFactory.ValidateAndCreate(email, password, name);

            _userRepository.AddUser(user);

            return true;
        }
    }
}