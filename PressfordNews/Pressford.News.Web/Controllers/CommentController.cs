using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Pressford.News.Domain;
using Pressford.News.Web.Filters;
using Pressford.News.Domain.Repositories;
using Pressford.News.Web.Controllers.ModelBuilder;
using Ninject;
using Pressford.News.Domain.Entities;

namespace Pressford.News.Web.Controllers
{
    [NewsDbContextFilter(typeof(NewsDbContext))]
    public class CommentController : ApiController
    {

        private readonly IArticleRepository _articleRepository;
        private readonly INewsDtoBuilder _newsDtoBuilder;

        public CommentController()
            : this(IoC.Kernal.Get<IArticleRepository>(), IoC.Kernal.Get<INewsDtoBuilder>())
        {

        }

        public CommentController(IArticleRepository articleRepository, INewsDtoBuilder newsDtoBuilder)
        {
            _articleRepository = articleRepository;
            _newsDtoBuilder = newsDtoBuilder;
        }

        [HttpPost]
        public HttpResponseMessage Add(CommentRequest commentRequest)
        {
            //check of article exists
            var article = _articleRepository.GetArticleById(commentRequest.ArticleId);
            
            var comment = new Comment
            {
                Text = commentRequest.Message,
                ArticleId = article.Id
            };

            _articleRepository.AddComment(comment);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        public HttpResponseMessage Update(CommentRequest commentRequest)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
