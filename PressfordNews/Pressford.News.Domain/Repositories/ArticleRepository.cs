using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pressford.News.Domain.Entities;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace Pressford.News.Domain.Repositories
{

    public class ArticleRepository : IArticleRepository
    {
        private const string DBCONTEXT_KEY = "Pressford.DbContext_Pressford.News.Domain.NewsDbContex";

        public IList<Article> GetLatestArticles()
        {
            var articles = (from a in DbContext().Article
                                .Include(y => y.Comments)
                            select a)
                                .OrderByDescending(x => x.CreatedDate).ToList();
            return articles;
        }

        public IList<Entities.Article> GetArticlesByStatus(ArticleStatus articleStatus)
        {
            var articles = (from a in DbContext().Article
                                .Include(y => y.Comments)
                           //// where (a.Status == articleStatus)
                            select a)
                                .OrderByDescending(x => x.CreatedDate).ToList();
            return articles;
        }

        public Entities.Article GetArticleById(int articleId)
        {
            return (from a in DbContext().Article
                               .Include(y => y.Comments)
                    where (a.Id == articleId)
                    select a).FirstOrDefault();
        }

        private NewsDbContext DbContext()
        {
            return (NewsDbContext)CallContext.LogicalGetData(DBCONTEXT_KEY);
        }



        public void AddComment(Comment comment)
        {
            comment.CreatedBy = "rhandoo";
            comment.CreatedDate = DateTime.Now;
            DbContext().Comment.Add(comment);
            DbContext().SaveChanges();
        }
    }
}
