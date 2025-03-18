// // using Azure;
// using Azure.Core;
// using Azure.AI.OpenAI;
// // using OpenAI.Chat;

// var endpoint = new Uri("https://namgo-m8aoumr9-eastus2.cognitiveservices.azure.com/");
// var credential = new Azure.AzureKeyCredential("539ByhIaNBPnGwYVW8Ax2JWzYmaTZcvA8QaFPIKEZ6CO8ZimTmejJQQJ99BCACHYHv6XJ3w3AAAAACOG8sgV");


// var client = new OpenAIClient(endpoint, credential);
// var deploymentName = "gpt-4o";
// var response = client.GetChatCompletions(deploymentName, new ChatCompletionsOptions()
// {
//     Messages = { new ChatMessage(ChatRole.User, "What is the purpose of life?") },
//     MaxTokens = 4096,
//     Temperature = 1.0f,
// });

// Console.WriteLine(response.Value.Choices[0].Message.Content);

using System;
using Azure;
using Azure.AI.OpenAI;

class Program
{
    static void Main()
    {
        var endpoint = new Uri("https://namgo-m8aoumr9-eastus2.cognitiveservices.azure.com/");
        var credential = new AzureKeyCredential("539ByhIaNBPnGwYVW8Ax2JWzYmaTZcvA8QaFPIKEZ6CO8ZimTmejJQQJ99BCACHYHv6XJ3w3AAAAACOG8sgV");

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
