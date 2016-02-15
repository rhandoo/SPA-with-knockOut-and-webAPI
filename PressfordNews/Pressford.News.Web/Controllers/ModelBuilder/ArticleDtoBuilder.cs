using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pressford.News.Web.Models;
using Pressford.News.Domain.Entities;

namespace Pressford.News.Web.Controllers.ModelBuilder
{
    public class ArticleDtoBuilder : IArticleDtoBuilder
    {
        private readonly ICommentDtoBuilder _commentDtoBuilder;
        public ArticleDtoBuilder(ICommentDtoBuilder commentDtoBuilder)
        {
            _commentDtoBuilder = commentDtoBuilder;
        }

        public ArticleDto Build(Article article)
        {
            var commentDtos = new List<CommentDto>();
            var likesDto = new List<LikeDto>();

            foreach (var comment in article.Comments)
            {
                var commentDto = _commentDtoBuilder.Build(comment);
                commentDtos.Add(commentDto);
            }

            return new ArticleDto
            {
                ArticleId = article.Id,
                Author = article.CreatedBy,
                Title = article.Title,
                Content = article.Content,
                Comments = commentDtos,
                Likes = likesDto
            };
        }
    }
}