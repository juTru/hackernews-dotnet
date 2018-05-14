using System;
using System.ComponentModel.DataAnnotations;

namespace hackernews
{
    public class HackerPost
    {
        [StringLength(256)]
        public string title { get; set; }
        public string uri { get; set; }
        public string author { get; set; }
        public int points { get; set; }
        public int comments { get; set; }
        public int rank { get; set; }

        public HackerPost(string title, string uri, string author, int points, int comments, int rank) 
        {
            this.title = title;
            this.uri = uri;
            this.author = author;
            this.points = points;
            this.comments = comments;
            this.rank = rank;
        }
    }
}
