using Tweetinvi;
using Tweetinvi.Models;
using System;
using System.Threading.Tasks;

var userCredentials = new TwitterCredentials("nN2yYQcMWlhsvaa8awvHo9PWF", "MDGDCAAhOaA3BSVMSz5HF2LElow39rdJlPJxdQO9z1E4pZ03b3", "1629692186-BimLBhF2MUQZ5ufDZ4G93ufBy7byABzijbZcNqQ", "hdY2py8hMvdSb7tU0a0wDxLmkKZrH7Gj24P7XL0SpAjTo");
var userClient = new TwitterClient(userCredentials);

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


// Create a simple stream containing only tweets with the keyword France

var stream = userClient.Streams.CreateFilteredStream();
stream.AddTrack("java");
stream.AddTrack("python");
stream.AddTrack("csharp");
stream.AddTrack("javascript");

int counter1 = 0;
int counter2 = 0;
int counter3 = 0;
int counter 4 = 0;

stream.MatchingTweetReceived += (sender, eventReceived) =>
{
    Console.WriteLine(eventReceived.Tweet);
};

await stream.StartMatchingAnyConditionAsync();