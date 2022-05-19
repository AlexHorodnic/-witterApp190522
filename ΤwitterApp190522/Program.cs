using System;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;

namespace Program
{
    internal class Program
    {
        static async Task Main(string[] args)
        {



            string filter1 = "javascript";
            string filter2 = "python";
            string filter3 = "c#";
            string filter4 = "java";

            var userCredentials = new TwitterCredentials("nN2yYQcMWlhsvaa8awvHo9PWF", "MDGDCAAhOaA3BSVMSz5HF2LElow39rdJlPJxdQO9z1E4pZ03b3", "1629692186-BimLBhF2MUQZ5ufDZ4G93ufBy7byABzijbZcNqQ", "hdY2py8hMvdSb7tU0a0wDxLmkKZrH7Gj24P7XL0SpAjTo");
            var userClient = new TwitterClient(userCredentials);

            // Create a simple stream containing only tweets with the keyword France

            var stream = userClient.Streams.CreateFilteredStream();
            stream.AddTrack(filter1);
            stream.AddTrack(filter2);
            stream.AddTrack(filter3);
            stream.AddTrack(filter4);

            int counter1 = 0;
            int counter2 = 0;
            int counter3 = 0;
            int counter4 = 0;

            var howManyTweetsSoFar = 0;

            stream.MatchingTweetReceived += (sender, eventReceived) =>
            {

                Console.WriteLine(eventReceived.Tweet);

                ITweet tweet = eventReceived.Tweet;
                string tweetText = tweet.FullText;
                int favoriteCount = tweet.FavoriteCount;
                string tweetAuthorName = tweet.CreatedBy.Name;


                Console.WriteLine();
                Console.WriteLine(tweetAuthorName + " " + favoriteCount);
                Console.WriteLine(tweetText);

                if (tweetText.Contains(filter1))
                {
                    counter1++;
                }
                if (tweetText.Contains(filter2))
                {
                    counter2++;
                }

                if (tweetText.Contains(filter3))
                {
                    counter3++;
                }

                if (tweetText.Contains(filter4))
                {
                    counter4++;
                }




                Console.WriteLine(
                    filter1 + ":" + counter1 + ", " +
                    filter2 + ":" + counter2 + ", " +
                    filter3 + ":" + counter3 + ", " +
                    filter4 + ":" + counter4
                    );
                Console.WriteLine("-------------------------");

                if (howManyTweetsSoFar == 10)
                {
                    stream.Stop();
                    Console.WriteLine("Complete!");
                }
            };

            await stream.StartMatchingAnyConditionAsync();


        }

    }
}
