using System;

namespace EmployeeAssistant.Core.Exceptions
{
    public abstract class BusinessLogicException : ArgumentException
    {
        public new Exception InnerException { get; }
        
        protected BusinessLogicException(string message, Exception inner) : base(message, inner)
        {
            InnerException = inner;
        }

        protected BusinessLogicException(string message) : base(message)
        {
            
        }
    }
}