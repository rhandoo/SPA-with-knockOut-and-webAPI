using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pressford.News.Web.Controllers
{
    public class CommentRequest
    {
        [Required]
        public int ArticleId { get; set; }

        [Required]
        public string Message { get; set; }
    }
}