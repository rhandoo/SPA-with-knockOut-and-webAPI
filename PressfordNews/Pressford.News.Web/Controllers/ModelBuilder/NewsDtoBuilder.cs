using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pressford.News.Web.Models;
using Pressford.News.Domain.Entities;

namespace Pressford.News.Web.Controllers.ModelBuilder
{
    public class NewsDtoBuilder : INewsDtoBuilder
    {
        public readonly IArticleDtoBuilder _articleDtoBuilder;
        public NewsDtoBuilder(IArticleDtoBuilder articleDtoBuilder)
        {
            _articleDtoBuilder = articleDtoBuilder;
        }

        public NewsDto GetLatestNewsArticles(IList<Article> articles)
        {
            var articleDtos = new List<ArticleDto>();

            foreach (var article in articles)
            {
                var articleDto = _articleDtoBuilder.Build(article);
                articleDtos.Add(articleDto);
            }

            return new NewsDto
            {
                Articles = articleDtos
            };
        }
    }
}