namespace EmployeeAssistant.IO.Telegram.Handlers
{
    public interface IQuestionHandler
    {
        public object Handle(string question);
    }
}