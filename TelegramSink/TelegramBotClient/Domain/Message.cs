using System.Text.Json.Serialization;

namespace TelegramSink.TelegramBotClient.Domain
{
    public class Chat
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    /// <summary>
    /// Informacion referente al bot con el cual estamos
    /// interactuando.
    /// </summary>
    public class From
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("is_bot")]
        public bool IsBot { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }
    }

    public class ResultMessage
    {
        [JsonPropertyName("message_id")]
        public int MessageId { get; set; }

        [JsonPropertyName("from")]
        public From From { get; set; }

        [JsonPropertyName("chat")]
        public Chat Chat { get; set; }

        [JsonPropertyName("date")]
        public int Date { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }
    }

    /// <summary>
    /// Respuesta recibida al enviar un mensaje a https://api.telegram.org/botXXXX/sendMessage?
    /// </summary>
    public class SendMessageResponse
    {
        [JsonPropertyName("ok")]
        public bool Ok { get; set; }

        [JsonPropertyName("result")]
        public ResultMessage ResultMessage { get; set; }
    }


}