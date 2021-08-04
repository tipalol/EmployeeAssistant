namespace EmployeeAssistant.Core
{
    public class User
    {
        public string Name { get; }
        
        public Password Password { get; }
        
        public Email Email { get; }

        internal User(string name, Password password, Email email)
        {
            Name = name;
            Password = password;
            Email = email;
        }
    }
}