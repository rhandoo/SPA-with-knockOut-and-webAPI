using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pressford.News.Web.Models
{
    public class CommentDto
    {
        public int CommentId { get; set; }

        public int ArticleId { get; set; }

        public string Message { get; set; }

        public string CommentedBy { get; set; }

        public string CommentedDate { get; set; }
    }
}