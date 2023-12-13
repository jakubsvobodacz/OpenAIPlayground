// See https://aka.ms/new-console-template for more information
using Azure;
using Azure.AI.OpenAI;
using static System.Environment;
using Microsoft.Extensions.Configuration;

// Build configuration & get data from json config
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        // Get values from appsettings.json
        var openAIEndpoint = config.GetSection("OpenAIEndpoint").Value;
        var key = config.GetSection("APIKey").Value;


//Interact with the user
Console.WriteLine("Ask me a question and I will answer it!");
var question = Console.ReadLine();
if (string.IsNullOrWhiteSpace(question))
        {
            Console.WriteLine("Please enter a valid question.");
            return;
        }


//Build message list
List<ChatRequestUserMessage> questions = new List<ChatRequestUserMessage>();
var acceptedQuestion = new ChatRequestUserMessage(question);
questions.Add(acceptedQuestion);


//Build the client & send request for completion
var client = new OpenAIClient(new Uri(openAIEndpoint), new AzureKeyCredential(key));
var options = new ChatCompletionsOptions("hackathon", questions){
    MaxTokens = 50
};
var gptResponse = await client.GetChatCompletionsAsync(options);

// Output the result  
Console.WriteLine(gptResponse.Value.Choices[0].Message.Content);
Console.WriteLine("this is it...");