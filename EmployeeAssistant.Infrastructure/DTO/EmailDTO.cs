using EmployeeAssistant.Core.Factories;

namespace EmployeeAssistant.Infrastructure.DTO
{
    public class EmailDto : IEmailDto
    {
        public string UserName { get; set; }
        public string MailHost { get; set; }
    }
}