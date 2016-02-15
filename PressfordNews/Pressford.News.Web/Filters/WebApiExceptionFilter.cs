using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http;
using System.IO;
using System.Net.Http;
using System.Net;
using Pressford.News.Web.ExceptionHandling;


namespace Pressford.News.Web.Filters
{
    public class WebApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var exception = context.Exception;
            var id = Guid.NewGuid();
            exception.Data.Add("Id", id);
            if (context.Exception == null || context.Exception.GetType() == typeof(HttpResponseException))
            {
                return;
            }

            TraceLog.Create(id + "-" + exception.Message);

            ////TODO Return Customised exceptions
            context.Response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, id);

        }
    }
}