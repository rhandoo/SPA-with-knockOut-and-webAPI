using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pressford.News.Web.Controllers
{
    public class ArticleRequest
    {
        [Required]
        public int ArticleId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Details { get; set; }

    }
}