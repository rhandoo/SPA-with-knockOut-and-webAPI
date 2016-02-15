using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pressford.News.Domain.Entities
{
    public class Like
    {
        public int Id { get; set; }

        public int ArticleId { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }
    }
}
