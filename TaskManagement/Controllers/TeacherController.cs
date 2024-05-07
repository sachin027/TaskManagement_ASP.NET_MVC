using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagement.CustomFilter;

namespace TaskManagement.Controllers
{

    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult TeacherDashboard()
        {
            return View();
        }
    }
}