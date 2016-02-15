using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pressford.News.Domain.Entities;

namespace Pressford.News.Domain.Repositories
{
    public interface IArticleRepository
    {
        IList<Article> GetLatestArticles();

        IList<Article> GetArticlesByStatus(ArticleStatus articleStatus);

        Article GetArticleById(int articleId);

        void AddComment(Comment comment);
      
    }
}
