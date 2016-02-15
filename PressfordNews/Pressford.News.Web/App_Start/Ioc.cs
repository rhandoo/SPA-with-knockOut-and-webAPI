using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Pressford.News.Domain.Repositories;
using Pressford.News.Web.Controllers.ModelBuilder;

namespace Pressford.News.Web
{
    /// <summary>
    ///  Class to implement DI using ninject 
    /// </summary>
    /// 
    public static class IoC
    {
        public static StandardKernel Kernal { get; private set; }

        public static void RegisterTypes()
        {
            Kernal = new StandardKernel();

            // Repository
            Kernal.Bind<IArticleRepository>().To<ArticleRepository>();
            Kernal.Bind<ICommentDtoBuilder>().To<CommentDtoBuilder>();
            Kernal.Bind<IArticleDtoBuilder>().To<ArticleDtoBuilder>();
            Kernal.Bind<INewsDtoBuilder>().To<NewsDtoBuilder>();
        }
    }
}