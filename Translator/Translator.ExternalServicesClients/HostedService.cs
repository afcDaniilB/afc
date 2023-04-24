﻿using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator.ExternalServicesClients
{
    public class HostedService : IHostedService
    {
        private readonly TGBotClient botClient;

        public HostedService(TGBotClient botClient) 
        {
            this.botClient = botClient;
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
            message = "будь здоров";
            botClient.SendMessage(chatId, message);
        }

        private void BotClient_StartMsg(long chatId, string message)
        {
            message = "Салам алейкум";
            botClient.SendMessage(chatId, message);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
