using System;

namespace EmployeeAssistant.Core.Exceptions
{
    public class EmptyUserNameOrMailHostException : BusinessLogicException
    {
        public string UserName { get; }
        public string MailHost { get; }
        
        internal EmptyUserNameOrMailHostException(string message, Exception inner, string userName, string mailHost) : base(message, inner)
        {
            UserName = userName;
            MailHost = mailHost;
        }

        public EmptyUserNameOrMailHostException(string message, string userName, string mailHost) : base(message)
        {
            UserName = userName;
            MailHost = mailHost;
        }
    }
}