using System;
using System.Security.Authentication;
using System.Threading.Tasks;
using EmployeeAssistant.Core.Security;
using EmployeeAssistant.Core.Services;

namespace EmployeeAssistant.Core.Factories
{
    public class UserFactory
    {
        private const string AuthenticationErrorMessage = "User with specified email and password not found";
        private const string EmailValidationErrorMessage = "Error while processing specified email";

        public static async Task<User> ValidateAndCreate(string email, string password, string name)
        {
            var validatedEmail = ValidateEmail(email);
            var encryptedPassword = new Password(EncryptionService.Encrypt(password));
            
            ThrowIfNull(validatedEmail);
            
            var validator = new ValidateAccountCredentialService();
            
            var valid = await validator.Validate(validatedEmail, encryptedPassword);
            
            if (valid == false)
                throw new AuthenticationException(AuthenticationErrorMessage);

            var user = new User(name, encryptedPassword, validatedEmail);

            return user;
        }

        public static User CreateFromDto(IUserDto userDto)
        {
            var email = new Email(userDto.Email.UserName, userDto.Email.MailHost);
            var pass = new Password(userDto.Password.Value);
            var user = new User(userDto.Name, pass, email);

            return user;
        }

        private static Email ValidateEmail(string email)
        {
            var (name, host) = Split(email);
            var validatedEmail = new Email(name, host);

            return validatedEmail;
        }

        private static (string name, string host) Split(string email)
        {
            var split = email
                .Split('@');

            return (split[0], split[1]);
        }

        private static void ThrowIfNull(object nullable)
        {
            if (nullable == null)
                throw new ArgumentException(EmailValidationErrorMessage);
        }
    }
}