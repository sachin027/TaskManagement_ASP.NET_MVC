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
    [CustomAuthorize]
    [CustomStudentAuthorize]
    public class StudentController : Controller
    {
        private readonly IAssignTask _assignTask;
        private readonly IStudentInterface _studentInterface;

        public StudentController()
        {
            this._assignTask = new AssignTaskService();
            this._studentInterface = new StudentService();
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


        /// <summary>
        /// Log out from dashboard and redirect to Login page - session  will end
        /// </summary>

        public ActionResult Logout()
        {
            Session.Clear();
            TempData["success"] = "Logout successfully ";
            return RedirectToAction("Index" , "LoginSignup");
        }


        ///<summary>
        ///Update assignment status
        /// </summary>
        public ActionResult SetAssignmentStatus(int id)
        {

            bool setStatus = _studentInterface.AssignmentStatus(id);

            if (setStatus)
            {
                return RedirectToAction("AssignmentList", "Student");
            }

            return RedirectToAction("AssignmentList");
        }
    }
}