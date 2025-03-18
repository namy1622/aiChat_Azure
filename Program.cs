
using System;
using Azure;
using Azure.AI.OpenAI;

class Program
{
    static void Main()
    {
        var endpoint = new Uri("https://namgo-m8aoumr9-eastus2.cognitiveservices.azure.com/");
        var credential = new AzureKeyCredential("539ByhIzsdaNBPnGwYVW8Ax2JWzYmaTZcgzasvA8QaFPIKsdZ6CO8ZimTmejJQQJ99BCACHYHv6XJ3w3AAAAACOG8sgV");

        // Sử dụng OpenAIClient thay vì ChatCompletionsClient
        var client = new OpenAIClient(endpoint, credential);
        
        Console.Write("- Bạn: ");
        var mess = Console.ReadLine();
        var chatOptions = new ChatCompletionsOptions()
        {
            Messages =
            {
                new ChatMessage(ChatRole.User, mess)
            },
            MaxTokens = 100,
            Temperature = 1.0f,
           
        };

        // Gửi yêu cầu và nhận phản hồi
        Response<ChatCompletions> response = client.GetChatCompletions("gpt-4o", chatOptions);

        Console.WriteLine("-> answer: " + response.Value.Choices[0].Message.Content);
    }
}
