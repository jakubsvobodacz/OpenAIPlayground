// See https://aka.ms/new-console-template for more information
using Azure;
using Azure.AI.OpenAI;
using static System.Environment;
using Microsoft.Extensions.Configuration;

//Get appsettings
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();


var endpoint = config.GetConnectionString("OpenAIEndpoint");
var key = config.GetConnectionString("APIKey");

var client = new OpenAIClient(new Uri(endpoint), new AzureKeyCredential(key));
Console.WriteLine("Hello, World!");
