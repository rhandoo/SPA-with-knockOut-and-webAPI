using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pressford.News.Web.Controllers
{
    public class LikeController : ApiController
    {

        [HttpPost]
        public HttpResponseMessage Add(int articleId)
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
