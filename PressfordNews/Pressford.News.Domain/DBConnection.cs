﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Pressford.News.Domain
{
    public static class DBConnection
    {
        public static SqlConnection Create (string connectionString)
        {
           return new SqlConnection(connectionString);
        }
    }
}
