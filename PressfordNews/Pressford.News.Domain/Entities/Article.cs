using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pressford.News.Domain.Entities
{
    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public IList<Comment> Comments { get; set; }

        public IList<Like> Likes { get; set; }

        ////public ArticleStatus Status { get; set; }

        //public void Add(Comment Comment)
        //{

        //}

        ////public void Add(Like Like)
        ////{

        ////}

        ////public void Update(string title, string content)
        ////{ 
        ////}

        ////public void Publish()
        ////{
        ////}

        ////public void Delete()
        ////{
        ////}
    }
}
