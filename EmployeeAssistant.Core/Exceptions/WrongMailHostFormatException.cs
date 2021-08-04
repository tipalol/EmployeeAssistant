using System;

namespace EmployeeAssistant.Core.Exceptions
{
    public class WrongMailHostFormatException : BusinessLogicException
    {
        public string MailHost { get; }
        
        internal WrongMailHostFormatException(string message, Exception inner, string mailHost) : base(message, inner)
        {
            MailHost = mailHost;
        }

        public WrongMailHostFormatException(string message, string mailHost) : base(message)
        {
            MailHost = mailHost;
        }
    }
}