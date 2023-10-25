using System;
using RestSharp;
using TelegramSink.TelegramBotClient.Domain;

namespace TelegramSink.TelegramBotClient
{
    public class Bot
    {
        private readonly BotConfiguration _botConfiguration;
        private const string TelegramApiBaseUrl = "https://api.telegram.org";

        private RestClient m_restClient = null;
        private string m_toBoot = string.Empty;

        public Bot(BotConfiguration botConfiguration)
        {
            _botConfiguration = botConfiguration;

            // Opciones de configuracion
            Uri uri = new Uri(TelegramApiBaseUrl);
            RestClientOptions options = new RestClientOptions(uri) { MaxTimeout = 5000 };
            string userAgent = "TelergamSink/0.1.2 (RestSharp; . Net Standard 2.1; rv:0) 20221010";
            options.UserAgent = userAgent;

            // Creamos el cliente, solo una instancia hace falta.
            m_restClient = new RestClient(options);

            // Debemos encodear el : del ApiKey - No debe empezar con '/bot' es solo 'bot'
            m_toBoot = string.Format("bot{0}/sendMessage", System.Net.WebUtility.UrlEncode(_botConfiguration.ApiKey));
        }


        public ResultMessage SendMessage(string message, string parse_mode = "Markdown")
        {
            var request = new RestRequest(m_toBoot, Method.Get);
            request.AddQueryParameter("parse_mode", parse_mode); // HTML or Markdown or MarkdownV2 or omitir este parametro.
            request.AddQueryParameter("chat_id", _botConfiguration.ChatId);
            request.AddQueryParameter("text", message);

            var response = m_restClient.Execute<SendMessageResponse>(request);

            return response.Data.ResultMessage;
        }
    }
}