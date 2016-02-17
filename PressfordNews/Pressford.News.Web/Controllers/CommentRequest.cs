using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Pressford.News.Web.Controllers
{
     public class CommentRequest
    {
        /// <summary>
        /// for ValueType we need add [DataMember(IsRequired=true)] and 
        /// for reference type we need to use 
        /// [Required]
        /// [DataMember]
        /// </summary>
        [DataMember(IsRequired=true)]
        public int ArticleId { get; set; }

        [Required]
        [DataMember]
        public string Message { get; set; }
    }
}