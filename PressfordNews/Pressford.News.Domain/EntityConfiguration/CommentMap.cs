using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using Pressford.News.Domain.Entities;

namespace Pressford.News.Domain.EntityConfiguration
{
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            HasKey(i => i.Id);
            ToTable("dbo.Comment");
        }
    }
}

