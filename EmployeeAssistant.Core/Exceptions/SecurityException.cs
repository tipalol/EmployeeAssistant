using System;
using System.Security.Cryptography;

namespace EmployeeAssistant.Core.Exceptions
{
    public class SecurityException : CryptographicException
    {
        public new Exception InnerException { get; }
        
        public SecurityException(string message, Exception inner) : base(message, inner)
        {
            InnerException = inner;
        }
    }
}