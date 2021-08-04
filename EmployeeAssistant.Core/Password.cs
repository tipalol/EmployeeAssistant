using System;
using EmployeeAssistant.Core.Security;

namespace EmployeeAssistant.Core
{
    public class Password
    {
        private readonly byte[] _password;

        internal Password(byte[] password)
        {
            _password = password;
        }

        public byte[] GetRawValue()
        {
            var result = new byte[_password.Length];
            
            Array.Copy(_password, result, _password.Length);

            return result;
        }

        internal string Read()
        {
            return DecryptionService.Decrypt(_password);
        }
    }
}