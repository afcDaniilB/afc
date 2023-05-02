using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Telegram.Bots.Types;
using System.ComponentModel.Design.Serialization;

namespace Translator.ExternalServicesClients
{
    public class HostedService : IHostedService
    {
        private readonly TGBotClient botClient;
        private readonly YandexTranslateService yandexTranslate;

        public HostedService(TGBotClient botClient, YandexTranslateService yandexTranslate) 
        {
            this.botClient = botClient;
            this.yandexTranslate = yandexTranslate;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            this.botClient.StartMsg += BotClient_StartMsg;
            this.botClient.UpdateMsg += BotClient_UpdateMsg;
            this.botClient.ErrorMsg += BotClient_ErrorMsg;

            return Task.CompletedTask;
        }

        private void BotClient_ErrorMsg(string message)
        {
            throw new NotImplementedException();
        }

        private void BotClient_UpdateMsg(long chatId, string message)
        {
            yandexTranslate.ExgSymbol("api/v3/exchangeInfo?symbol=BNBBTC");
            message = "ок пон";
            botClient.SendMessage(chatId, message);
            

        }

        private void BotClient_StartMsg(long chatId, string message)
        {
            yandexTranslate.ExgInfo("api/v3/exchangeInfo");
            message = "привет";
            botClient.SendMessage(chatId, message);

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
