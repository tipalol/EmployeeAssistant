using EmployeeAssistant.Core.Factories;

namespace EmployeeAssistant.Infrastructure.DTO
{
    public class UserDto : IUserDto
    {
        public string _id { get; set; }
        
        public string Name { get; set; }
        
        public IPasswordDto Password { get; set; }
        
        public IEmailDto Email { get; set; }
    }
}