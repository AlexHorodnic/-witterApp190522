using Tweetinvi;
using Tweetinvi.Models;

var userCredentials = new TwitterCredentials("CONSUMER_KEY", "CONSUMER_SECRET", "ACCESS_TOKEN", "ACCESS_TOKEN_SECRET");
var userClient = new TwitterClient(userCredentials);

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
