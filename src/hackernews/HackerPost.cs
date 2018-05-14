using System;
using System.ComponentModel.DataAnnotations;

namespace hackernews
{
    public class HackerPost
    {
		[Required]
        [StringLength(256)]
        public string title { get; set; }

		[Required]
        public string uri { get; set; }

		[Required]
        [StringLength(256)]
        public string author { get; set; }

		[Range(0, Int32.MaxValue)]
        public int points { get; set; }
        
		[Range(0, Int32.MaxValue)]
        public int comments { get; set; }

		[Range(0, Int32.MaxValue)]
        public int rank { get; set; }

        public HackerPost(string title, string uri, string author, int points, int comments, int rank) 
        {
            this.title = title;
			if (Uri.IsWellFormedUriString(uri, UriKind.Absolute))
			{
				this.uri = uri;
			}
            this.author = author;
            this.points = points;
            this.comments = comments;
            this.rank = rank;
        }
    }
}
