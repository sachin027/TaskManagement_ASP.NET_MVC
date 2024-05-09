using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagement.CustomFilter;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;
using TaskManagement.Repository.Interface;
using TaskManagement.Repository.Services;

namespace TaskManagement.Controllers
{
    [CustomAuthorize]
    [CustomTeacherAuthorize]

    public class TeacherController : Controller
    {
        private readonly IAssignTask _task;
        private readonly IAddTask _addTask;
        private readonly ITeacherInterface _teacherInterface;
        public TeacherController()
        {
            this._task = new AssignTaskService();
            this._addTask = new AddTaskService();
            this._teacherInterface = new TeacherService();
        }

        // GET: Teacher
        public ActionResult TeacherDashboard()
        {
            return View();
        }

        //Create new Task

        public ActionResult CreateTask()
        {
            Teachers _teacher = _teacherInterface.GetTeacherByUsername(SessionHelper.SessionHelper.Username);
            ViewBag.TeacherId = _teacher.TeacherID;
            return View();
        }

        [HttpPost]
        public ActionResult CreateTask(TaskModel customTaskModel)
        {
            try
            {
                if(customTaskModel != null)
                {
                    _addTask.AddTask(customTaskModel);
                    return RedirectToAction("TeacherDashboard");
                }
                else
                {
                    return View("CreateTask");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        ///Assign task to students
        public ActionResult AssignTask()
        {
            List<StudentModel> _studentList = new List<StudentModel>();
            _studentList = _task.GetStudentList();
            ViewBag._studentlist = _studentList; 

            List<TaskModel> _taskList = new List<TaskModel>();
            _taskList = _task.GetTaskList();
            ViewBag._taskList = _taskList;
            
            return View();
        }

        [HttpPost]
        public ActionResult AssignTask(AssignmentModel assignmentModel)
        {
            try
            {
                bool isSaving = _task.AssignTaskToStudent(assignmentModel);

                if (isSaving)
                {
                    return RedirectToAction("TeacherDashboard");
                }
                return View();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        /// <summary>
        /// Log out from dashboard and redirect to Login page - session  will end
        /// </summary>

        public ActionResult Logout()
        {
            Session.Clear();
            TempData["success"] = "Logout successfully ";
            return RedirectToAction("Index", "LoginSignup");
        }

    }
}