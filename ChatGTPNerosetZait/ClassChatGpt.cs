using System.Net.Http;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Reflection.Metadata.Ecma335;

namespace ChatGTPNerosetZait
{
    public class ClassChatGpt
    {
        public static string MessBot { get; set; }
        public static List<Message> messages = new List<Message>();

        public static async Task CreateMessage(string contenti)
        {
            // токен из личного кабинета
            string apiKey = "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";
            // адрес api для взаимодействия с чат-ботом
            string endpoint = "https://api.openai.com/v1/chat/completions";
            // набор соообщений диалога с чат-ботом

            // HttpClient для отправки сообщений
            var httpClient = new HttpClient();
            // устанавливаем отправляемый в запросе токен
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");


            var content = contenti;

            // если введенное сообщение имеет длину меньше 1 символа
            // то выходим из цикла и завершаем программу
            if (content is not { Length: > 0 }) { }
            // формируем отправляемое сообщение
            var message = new Message() { Role = "user", Content = content };
            // добавляем сообщение в список сообщений
            messages.Add(message);

            // формируем отправляемые данные
            var requestData = new Request()
            {
                ModelId = "gpt-3.5-turbo",
                Messages = messages
            };
            // отправляем запрос
            using var response = await httpClient.PostAsJsonAsync(endpoint, requestData);

            // если произошла ошибка, выводим сообщение об ошибке на консоль
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"{(int)response.StatusCode} {response.StatusCode}");
            }
            // получаем данные ответа
            ResponseData? responseData = await response.Content.ReadFromJsonAsync<ResponseData>();

            var choices = responseData?.Choices ?? new List<Choice>();
            if (choices.Count == 0)
            {
                MessBot = "No choices were returned by the API";
            }
            var choice = choices[0];
            var responseMessage = choice.Message;
            // добавляем полученное сообщение в список сообщений
            messages.Add(responseMessage);
            var responseText = responseMessage.Content.Trim();

            MessBot = responseText;
        }

    }
}