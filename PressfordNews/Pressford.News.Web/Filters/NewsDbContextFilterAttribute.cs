using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;

namespace Pressford.News.Web.Filters
{
    public class NewsDbContextFilterAttribute : ActionFilterAttribute
    {
        private readonly Type _dbContextType;

        private const string DBCONTEXT_KEY = "Pressford.DbContext_Pressford.News.Domain.NewsDbContex";

        public NewsDbContextFilterAttribute(Type dbContextType)
        {
            _dbContextType = dbContextType;
        }

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var dbContext = Activator.CreateInstance(_dbContextType);

            CallContext.LogicalSetData(DBCONTEXT_KEY, dbContext);
            base.OnActionExecuting(actionContext);
        }


        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
            var currentContext = GetCurrentContext();
            CallContext.LogicalSetData(DBCONTEXT_KEY, null);

            if (currentContext != null)
            {
                currentContext.Dispose();
            }

        }

        private DbContext GetCurrentContext()
        {
            return (DbContext)CallContext.LogicalGetData(DBCONTEXT_KEY);

        }
    }
}