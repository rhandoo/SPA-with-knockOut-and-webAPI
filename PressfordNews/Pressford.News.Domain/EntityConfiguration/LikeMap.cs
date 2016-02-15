using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using Pressford.News.Domain.Entities;

namespace Pressford.News.Domain.EntityConfiguration
{
    public class LikeMap : EntityTypeConfiguration<Like>
    {
          public LikeMap()
        {
            ToTable("dbo.Article_Like");
        }
    }
}

