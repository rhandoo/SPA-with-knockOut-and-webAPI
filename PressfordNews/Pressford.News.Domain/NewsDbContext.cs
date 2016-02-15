using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Pressford.News.Domain.Entities;
using System.Data.Entity.Infrastructure;
using Pressford.News.Domain.EntityConfiguration;

namespace Pressford.News.Domain
{
    public class NewsDbContext:DbContext
    {
        public IDbSet<Article> Article { get; set; }

        public IDbSet<Comment> Comment { get; set; }

        public IDbSet<Like> Like { get; set; }

        public NewsDbContext():base(DBConnection.Create(Config.GetDatabaseConnectionString()),true)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException("modelBuilder");
            }

            modelBuilder.Configurations.Add(new ArticleMap());
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new LikeMap());


            base.OnModelCreating(modelBuilder);
        }
    }
}
