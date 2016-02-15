using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using Pressford.News.Domain.Entities;

namespace Pressford.News.Domain.EntityConfiguration
{
    public class ArticleMap:EntityTypeConfiguration<Article>
    {
        public ArticleMap()
        {
            ToTable("dbo.Article");
            HasMany(x => x.Comments).WithRequired().HasForeignKey(y => y.ArticleId);
            HasMany(x => x.Likes).WithRequired().HasForeignKey(y => y.ArticleId);
        }
    }
}
