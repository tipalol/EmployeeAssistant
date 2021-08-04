using System.Text.RegularExpressions;
using EmployeeAssistant.Core.Exceptions;

namespace EmployeeAssistant.Core
{
    public class Email
    {
        private const string EmptyUserNameOrMailHostMessage = "User Name or Mail Host was empty";
        private const string WrongMailHostFormatMessage = "Email host has wrong format";
        private const string NotBeelineMailHostException = "Mail host must be beeline.ru";

        private const string BeelineMailHost = "beeline.ru";
        private const string MailHostPattern = "^[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$";
        
        public string UserName { get; }
        public string MailHost { get; }

        internal Email(string userName, string mailHost)
        {
            ThrowIfEmpty(userName, mailHost);
            ThrowIfHostWrongFormat(mailHost);
            ThrowIfNotBeeline(mailHost);
            
            UserName = userName;
            MailHost = mailHost;
        }

        public override string ToString() => $"{UserName}@{MailHost}";

        private static void ThrowIfEmpty(string userName, string mailHost)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(mailHost))
                throw new EmptyUserNameOrMailHostException(EmptyUserNameOrMailHostMessage, userName, mailHost);
        }

        private static void ThrowIfHostWrongFormat(string mailHost)
        {
            const string pattern = MailHostPattern;
            var isMailHost = new Regex(pattern).IsMatch(mailHost);

            if (isMailHost == false)
                throw new WrongMailHostFormatException(WrongMailHostFormatMessage, mailHost);
        }

        private static void ThrowIfNotBeeline(string mailHost)
        {
            if (mailHost.Contains(BeelineMailHost) == false)
                throw new NotBeelineMailHostException(NotBeelineMailHostException, mailHost);
        }
    }
}