using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pressford.News.Web.Models
{
    public class ArticleDto
    {
        public int ArticleId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime ArticleDate { get; set; }

        public List<CommentDto> Comments { get; set; }

        public List<LikeDto> Likes { get; set; }

        public int NumberOfLikes
        {
            get { return Likes.Count(); }
        }

        public int NumberOfComments
        {
            get { return Comments.Count(); }
        }
    }
}