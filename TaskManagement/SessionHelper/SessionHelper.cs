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

        public static string Role
        {
            set
            {
                HttpContext.Current.Session["Role"] = value;
            }
            get
            {
                return HttpContext.Current.Session["Role"] == null ? "" : (string)HttpContext.Current.Session["Role"];
            }
        }

        public static string UserId
        {
            set
            {
                HttpContext.Current.Session["UserId"] = value;
            }
            get
            {
                return HttpContext.Current.Session["UserId"] == null ? "" : (string)HttpContext.Current.Session["UserId"];
            }
        }
    }
}