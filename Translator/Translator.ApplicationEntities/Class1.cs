using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using System.Threading;
using Newtonsoft.Json;

namespace Translator.ApplicationEntities
{
    public class TranslatorEntities
    {
        public class Langs
        {
            [JsonProperty("ru")]
            public string Ru { get; set; }

            [JsonProperty("en")]
            public string En { get; set; }

            [JsonProperty("de")]
            public string De { get; set; }

            [JsonProperty("nl")]
            public string Nl { get; set; }

            [JsonProperty("sv")]
            public string Sv { get; set; }

            [JsonProperty("fr")]
            public string Fr { get; set; }

            [JsonProperty("fi")]
            public string Fi { get; set; }

            [JsonProperty("zh")]
            public string Zh { get; set; }

            [JsonProperty("es")]
            public string Es { get; set; }

            [JsonProperty("tr")]
            public string Tr { get; set; }

            [JsonProperty("pl")]
            public string Pl { get; set; }
        }

        public class Root
        {
            [JsonProperty("langs")]
            public Langs Langs { get; set; }
        }

    }
}

