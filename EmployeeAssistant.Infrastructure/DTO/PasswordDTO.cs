using EmployeeAssistant.Core.Factories;

namespace EmployeeAssistant.Infrastructure.DTO
{
    public class PasswordDto : IPasswordDto
    {
        public byte[] Value { get; set; }
    }
}