using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Pressford.News.Domain
{
    public enum ArticleStatus : int
    {
        [Description("Created")]
        Created = 1,

        [Description("Deleted")]
        Deleted = 2,

        [Description("Published")]
        Published = 3
    }
}
