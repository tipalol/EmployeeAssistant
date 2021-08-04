using System;

namespace EmployeeAssistant.Core.Exceptions
{
    public class NotBeelineMailHostException : BusinessLogicException
    {
        public string MailHost { get; }
        
        internal NotBeelineMailHostException(string message, Exception inner, string mailHost) : base(message, inner)
        {
            MailHost = mailHost;
        }

        internal NotBeelineMailHostException(string message, string mailHost) : base(message)
        {
            MailHost = mailHost;
        }
    }
}