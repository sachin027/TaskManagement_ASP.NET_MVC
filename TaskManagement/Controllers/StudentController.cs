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
            string name = SessionHelper.SessionHelper.Username;
            ViewBag.TotalAssignments = _studentInterface.TotalAssignments(name);
            ViewBag.TotalCompletedAssignment = _studentInterface.TotalCompletedAssignment(name);
            ViewBag.TotalPendingAssignment = _studentInterface.TotalPendingAssignment(name);
            return View();
        }

        public ActionResult AssignmentList()
        {
            string username = SessionHelper.SessionHelper.Username;
            List<Assignment> _assignments = _assignTask.GetAssignmentsListById(username);
            return View(_assignments);
        }

        /// <summary>  Log out from dashboard and redirect to Login page - session  will end
        public ActionResult Logout()
        {
            Session.Clear();
            TempData["success"] = "Logout successfully ";
            return RedirectToAction("Index" , "LoginSignup");
        }

        ///<summary> Update assignment status
        public ActionResult SetAssignmentStatus(int id)
        {

            bool setStatus = _studentInterface.AssignmentStatus(id);

            if (setStatus)
            {
                return RedirectToAction("AssignmentList", "Student");
            }

            return RedirectToAction("AssignmentList");
        }

        ///<summary> Return a Partial viewn for details
        public ActionResult Details(int id)
        {
            TaskManagement_452Entities _DBContext = new TaskManagement_452Entities();
            Assignment _Assignment = new Assignment();

            _Assignment = _DBContext.Assignment.Find(id);
            return PartialView("Details", _Assignment);
        }
    }
}