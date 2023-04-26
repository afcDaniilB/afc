using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Translator.ExternalServicesClients
{
    public class TGBotClient 
    {
        private ITelegramBotClient bot;
        public delegate void UpdateMessage(long chatId, string message);
        public event UpdateMessage UpdateMsg;

        public delegate void StartMessage(long chatId, string message);
        public event StartMessage StartMsg;

        public delegate void ErrorMessage(string message);
        public event ErrorMessage ErrorMsg;
        public TGBotClient()
        {
            bot = new TelegramBotClient("6249188380:AAEqTQNpIC7xZgc12TMqc5ZDqnLJGv-okDo");
            bot.StartReceiving(HandleUpdateAsync, HandleErrorAsync);

            Console.WriteLine("Бот запущен" + bot.GetMeAsync().Result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="botClient"></param>
        /// <param name="update"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var chatId = update.Message.Chat.Id;
                var message = update.Message;
                if (message.Text.ToLower() == "/start")
                {
                    StartMsg?.Invoke(chatId, "/start");
                    return;
                }

                UpdateMsg?.Invoke(chatId, message.Text);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="botClient"></param>
        /// <param name="exception"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken) =>
            ErrorMsg?.Invoke(exception.Message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chatId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessage(long chatId, string message) => await bot.SendTextMessageAsync(chatId, message);

    }
}
