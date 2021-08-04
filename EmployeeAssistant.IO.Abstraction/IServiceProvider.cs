using EmployeeAssistant.Infrastructure.DTO;

namespace EmployeeAssistant.IO.Abstraction
{
    public interface IServiceProvider
    {
        /// <summary>
        /// First time user login into the app 
        /// </summary>
        /// <param name="userDto">User credential</param>
        /// <returns>Result of the operation</returns>
        public Result Register(UserDto userDto);

        /// <summary>
        /// Registered user login into app
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        public Result Login(UserDto userDto);

        public Result Question(string question);
    }
}