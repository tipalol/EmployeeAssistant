using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeAssistant.Core;
using EmployeeAssistant.Core.Factories;
using EmployeeAssistant.Infrastructure.DTO;
using EmployeeAssistant.Infrastructure.Services;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EmployeeAssistant.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private const string Connection = "mongodb://admin:Adminqwerty123@83.229.82.177";

        private readonly MongoClient _client;
        private readonly IMongoDatabase _db;
        private IMongoCollection<UserDto> _users;

        public UserRepository()
        {
            MongoConfigService.AddImplementation<IPasswordDto, PasswordDto>();
            MongoConfigService.AddImplementation<IEmailDto, EmailDto>();
            MongoConfigService.AddImplementation<IUserDto, UserDto>();
            
            _client = new MongoClient(Connection);
            _db = _client.GetDatabase("users");
            _users = _db.GetCollection<UserDto>("users");
        }

        public void AddUser(User user)
        {
            var dto = ConvertUserToDto(user);
            
            _users.InsertOne(dto);
        }

        public User GetUser(string name)
        {
            var dto = _users.Find(u => u.Email.UserName.Equals(name)).ToList().First();
            var user = ConvertDtoToUser(dto);

            return user;
        }

        public List<User> GetUsers()
        {
            var dto = _users.Find(u => u.Name != null).ToList();

            var users = ConvertDtoToUser(dto);

            return users;
        }

        public async Task Clear()
        {
            await _db.DropCollectionAsync("users");
            await _db.CreateCollectionAsync("users");

            _users = _db.GetCollection<UserDto>("users");
        }

        private UserDto ConvertUserToDto(User user)
        {
            var dto = new UserDto()
            {
                Name = user.Name,
                Email = new EmailDto()
                {
                    MailHost = user.Email.MailHost,
                    UserName = user.Email.UserName
                },
                Password = new PasswordDto()
                {
                    Value = user.Password.GetRawValue()
                }
            };

            return dto;
        }

        private User ConvertDtoToUser(UserDto dto)
            => UserFactory.CreateFromDto(dto);

        private List<User> ConvertDtoToUser(IEnumerable<UserDto> dto)
            => dto.Select(ConvertDtoToUser).ToList();
    }
}