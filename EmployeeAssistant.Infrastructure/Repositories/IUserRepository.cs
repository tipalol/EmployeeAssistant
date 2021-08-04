using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeAssistant.Core;

namespace EmployeeAssistant.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        public void AddUser(User user);
        public User GetUser(string id);
        public List<User> GetUsers();
        public Task Clear();
    }
}