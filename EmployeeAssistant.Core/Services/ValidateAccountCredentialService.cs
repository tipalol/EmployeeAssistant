using System.Threading.Tasks;

namespace EmployeeAssistant.Core.Services
{
    internal class ValidateAccountCredentialService
    {
        internal Task<bool> Validate(Email email, Password password)
        {
            //TODO Connect to email
            return Task.Run(() => true);
        }
    }
}