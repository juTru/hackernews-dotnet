using System;
using System.Collections.Generic;
using RestSharp;

namespace hackernews
{
    public class HackerNewsApi
    {
        const string BaseUrl = "https://hacker-news.firebaseio.com/v0/";

        readonly RestClient client;

        public HackerNewsApi() 
        {
            this.client = new RestClient(BaseUrl);
        }

        private T Execute<T>(RestRequest request) where T : new()
        {
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response from HackerNews API.";
                throw new ApplicationException(message, response.ErrorException);
            }

            return response.Data;
        }

        public List<int> GetTopStories()
        {
            var request = new RestRequest("topstories.json", Method.GET);

            List<int> stories = Execute<List<int>>(request);
            return stories;
        }

        public HackerPost GetHackerPost(int postId)
        {
            var request = new RestRequest();
            request.Resource = "item/{postId}.json";
            request.Method = Method.GET;

            request.AddParameter("postId", postId, ParameterType.UrlSegment);

            HackerPostApiResponse post = Execute<HackerPostApiResponse>(request);
            return post.toHackerPost();
        }
         
    }

    public class HackerPostApiResponse
    {

        public string title { get; set; }
        public string url { get; set; }
        public string by { get; set; }
        public int score { get; set; }
        public List<int> kids { get; set; }
        public Type type { get; set; }
        public HackerPost toHackerPost()
        {
            return new HackerPost(this.title, this.url, this.by, this.score, this.kids.Count, (int)type);
        }

        public enum Type
        {
            job = 1,
            story = 2,
            comment=3,
            poll=4,
            pollopt=5
        }
    }

}
