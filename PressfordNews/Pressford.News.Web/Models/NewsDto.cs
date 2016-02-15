using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pressford.News.Web.Models
{
    public class NewsDto
    {

        public List<ArticleDto> Articles { get; set; }

        public ArticleDto ArticleMostLiked { get; set; }

    }
}