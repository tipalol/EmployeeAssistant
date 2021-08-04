using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace EmployeeAssistant.IO.Telegram.Handlers
{
    public class TelegramHandler : IUpdateHandler
    {
        private IQuestionHandler _questionHandler;

        public async Task HandleUpdate(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var chatId = update.Message.Chat.Id;

            //var flow = _questionHandler.Handle(update.Message.Text);
            //TODO start provided flow to handle user question

            await botClient.SendTextMessageAsync(chatId, "Привет, я еще ничего не умею :]", cancellationToken: cancellationToken);
        }

        public Task HandleError(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public UpdateType[]? AllowedUpdates { get; }

        private void Configure()
        {
            //TODO get information system question handler
            _questionHandler = new BaseQuestionHandler();
        }
    }
}