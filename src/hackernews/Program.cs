using System;
using System.Collections.Generic;

namespace hackernews
{
    class Program
    {
        public static void Main(string[] args)
        {
            string errorMessage = "Invalid cmd!";
            if (args.Length == 2 && args[0] == "--posts")
            {
                try
                {
                    int postsNumber = Int32.Parse(args[1]);
                    if (postsNumber >= 0 && postsNumber <= 100)
                    {
                        Run(postsNumber);
                        return;
                    }
                    else throw new Exception("Posts number should be an integer from 0 to 100.");

                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                }

            }
            Console.WriteLine(errorMessage);
        }

        static void Run(int postsNumber)
        {
            HackerNewsApi client = new HackerNewsApi();
            List<int> topStories = client.GetTopStories();

            for (int i = 0; i < postsNumber; i++)
            {
                HackerPost post = client.GetHackerPost(topStories[i]);

                RestSharp.Serializers.JsonSerializer serializer = new RestSharp.Serializers.JsonSerializer();
                Console.WriteLine(serializer.Serialize(post));
            }
        }

    }
}
