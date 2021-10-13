using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace UrlShortner.App_Code
{
    public class SqlDB
    {
        public static string ConnStr { get { return ConfigurationManager.ConnectionStrings["UrlShortnerConnectionString"].ToString(); } }
    }
}