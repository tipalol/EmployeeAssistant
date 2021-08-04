namespace EmployeeAssistant.Core.Factories
{
    public interface IUserDto
    {
        public string Name { get; set; }

        public IEmailDto Email { get; set; }
        
        public IPasswordDto Password { get; set; }
    }
}