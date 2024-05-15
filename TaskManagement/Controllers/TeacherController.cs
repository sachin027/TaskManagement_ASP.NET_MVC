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
        TaskManagement_452Entities _DBContext = new TaskManagement_452Entities();

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
            string name = SessionHelper.SessionHelper.Username;
            ViewBag.TotalCreatedTaskByTeacher = _task.TotalCreatedTaskByTeacher(name);
            ViewBag.TotalTaskAssignToStudent = _task.TotalTaskAssignedToStudent(name);
            ViewBag.TotalCompletedTaskByStudent = _task.TotalCompletedTaskByStudent(name);
            ViewBag.TotalPendingTaskByStudent = _task.TotalPendingTaskByStudent(name);
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
                if(customTaskModel != null && ModelState.IsValid)
                {
                    _addTask.AddTask(customTaskModel);
                    TempData["success"] = "Task added successfully";
                    return RedirectToAction("TeacherDashboard");
                }
                else
                {
                    TempData["error"] = "Something went wrong";
                    return View("CreateTask");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        ///Assign task to students
        public ActionResult AssignTask(int id)
        {
            List<StudentModel> _studentList = new List<StudentModel>();
            _studentList = _task.GetStudentListById(id);
            ViewBag._studentlist = _studentList; 

            List<TaskModel> _taskList = new List<TaskModel>();
            string username = SessionHelper.SessionHelper.Username;
            _taskList = _task.GetTaskList(username);
            ViewBag._taskList = _taskList;
            
            return View("AssignTask" );
        }

        [HttpPost]
        public ActionResult AssignTask(AssignmentModel assignmentModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isSaving = _task.AssignTaskToStudent(assignmentModel);

                    if (isSaving) //error : use of unsugned local variable
                    {
                        TempData["success"] = "Task assign successfully";
                        return RedirectToAction("TeacherDashboard");
                    }
                }
                TempData["error"] = "Something wrong";
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }

        /// <summary> redirect to all task list page which created by teacher .
        public ActionResult TaskList()
        {
            List<TaskModel> _taskList = new List<TaskModel>();
            string username = SessionHelper.SessionHelper.Username;
            _taskList = _task.GetTaskList(username);
            return View(_taskList);
        }

        //public ActionResult CompletedStudentList()
        //{
        //    int id = SessionHelper.SessionHelper.UserId;
        //    List<Assignment> assignmentModels = new List<Assignment>();
        //    assignmentModels = _task.TotalCompletedTaskByStudentList(id);
        //    return View(assignmentModels);
        //}

        /// <summary> Log out from dashboard and redirect to Login page - session  will end
        public ActionResult Logout()
        {
            Session.Clear();
            TempData["success"] = "Logout successfully ";
            return RedirectToAction("Index", "LoginSignup");
        }


        ///<summary> edit Task 
        public ActionResult Edit(int? id)
        {
            Tasks _task =  _DBContext.Tasks.FirstOrDefault(m => m.TaskID == id);
            return PartialView("_EditTask", _task);
        }

       
    }
}

