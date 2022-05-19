using Tweetinvi;
using Tweetinvi.Models;

var userCredentials = new TwitterCredentials("CONSUMER_KEY", "CONSUMER_SECRET", "ACCESS_TOKEN", "ACCESS_TOKEN_SECRET");
var userClient = new TwitterClient(userCredentials);

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


// Create a simple stream containing only tweets with the keyword France

var stream = userClient.Streams.CreateFilteredStream();
stream.AddTrack("java");

stream.MatchingTweetReceived += (sender, eventReceived) =>
{
    Console.WriteLine(eventReceived.Tweet);
};

await stream.StartMatchingAnyConditionAsync();