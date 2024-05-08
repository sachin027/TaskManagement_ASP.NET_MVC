using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagement.CustomFilter;
using TaskManagement.Models.DBContext;
using TaskManagement.Repository.Interface;
using TaskManagement.Repository.Services;

namespace TaskManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly IAssignTask _assignTask;

        public StudentController()
        {
            this._assignTask = new AssignTaskService();
        }
        // GET: Student
        public ActionResult StudentDashboard()
        {
            return View();
        }

        public ActionResult AssignmentList()
        {
            string username = SessionHelper.SessionHelper.Username;
            List<Assignment> _assignments = _assignTask.GetAssignmentsListById(username);
            return View(_assignments);
        }
    }
}