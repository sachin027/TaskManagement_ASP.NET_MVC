using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagement.SessionHelper
{
    public class SessionHelper
    {
        public static string Username
        {
            get
            {
                return HttpContext.Current.Session["Username"] == null ? "" : (string)HttpContext.Current.Session["Username"];
            }
            set
            {
                HttpContext.Current.Session["Username"] = value;
            }
        }
    }
}