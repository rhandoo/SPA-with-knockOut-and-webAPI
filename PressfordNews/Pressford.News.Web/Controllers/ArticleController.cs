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

namespace Pressford.News.Web.Controllers
{
    [NewsDbContextFilter(typeof(NewsDbContext))]
    public class ArticleController : ApiController
    {
        private readonly IArticleRepository _articleRepository;
        private readonly INewsDtoBuilder _newsDtoBuilder;

        public ArticleController():this(IoC.Kernal.Get<IArticleRepository>(),IoC.Kernal.Get<INewsDtoBuilder>())
        {
 
        }

        public ArticleController(IArticleRepository articleRepository, INewsDtoBuilder newsDtoBuilder)
        {
            _articleRepository = articleRepository;
            _newsDtoBuilder = newsDtoBuilder;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = _newsDtoBuilder.GetLatestNewsArticles(_articleRepository.GetLatestArticles());
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        public HttpResponseMessage Add(ArticleRequest articleRequest)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        public HttpResponseMessage Update(ArticleRequest articleRequest)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int articleId)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
