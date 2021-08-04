namespace EmployeeAssistant.Core.Factories
{
    public interface IEmailDto
    {
        public string UserName { get; set; }
        public string MailHost { get; set; }
    }
}