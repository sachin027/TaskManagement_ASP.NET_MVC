using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagement.CustomFilter;

namespace TaskManagement.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult StudentDashboard()
        {
            return View();
        }
    }
}