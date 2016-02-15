using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pressford.News.Web.Models;
using Pressford.News.Domain.Entities;

namespace Pressford.News.Web.Controllers.ModelBuilder
{
    public interface ICommentDtoBuilder
    {
        CommentDto Build(Comment comment);
    }
}
