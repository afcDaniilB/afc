using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Translator.ExternalServicesClients
{
    public static class ServiceCollection
    {
        public static void AddClient(this IServiceCollection services)
        {
            services.AddTransient<TGBotClient>();
            services.AddHostedService<HostedService>();
            services.AddTransient<YandexTranslateService>();
        }
    }
}
