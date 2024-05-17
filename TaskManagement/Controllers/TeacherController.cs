using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TaskManagement.Common;
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

        HttpClient _client = new HttpClient();

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
                if (customTaskModel != null && ModelState.IsValid)
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

            return PartialView("_AssignTask");
        }

        [HttpPost]
        public ActionResult AssignTask(AssignmentModel assignmentModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isSaving = _task.AssignTaskToStudent(assignmentModel);

                    if (isSaving)
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
        public ActionResult TaskList(int? pageNumber)
        {
            List<TaskModel> _taskList = new List<TaskModel>();
            string username = SessionHelper.SessionHelper.Username;
            _taskList = _task.GetTaskList(username);

            int page = pageNumber ?? 1;

           var _pagination = PaginatedList<TaskModel>.Pagination(_taskList, page);

            ViewBag.totalCount = PaginatedList<TaskModel>.totalCount;
            ViewBag.page = PaginatedList<TaskModel>.page;
            ViewBag.pageSize = PaginatedList<TaskModel>.pageSize;
            ViewBag.totalPage = PaginatedList<TaskModel>.totalPage;

            return View(_pagination);
            //return View(_taskList);
        }

        /// <summary> Get all task assigned student List
        public async Task<ActionResult> GetAllTaskAssignedStudentList()
        {
            int id = SessionHelper.SessionHelper.UserId;
            List<AssignmentModelList> assignmentModels = new List<AssignmentModelList>();
            assignmentModels = await WebAPIHelper.GetAllTaskAssignedStudentList();
            return View(assignmentModels);
        }

        /// <summary> Get all completed task student list
        public async Task<ActionResult> CompletedStudentList()
        {
            int id = SessionHelper.SessionHelper.UserId;
            List<AssignmentModelList> assignmentModels = new List<AssignmentModelList>();
            assignmentModels = await WebAPIHelper.CompletedStudentList();
            return View(assignmentModels);
        }

        /// <summary> Get all pending task student list
        public async Task<ActionResult> PendingStudentList()
        {
            int id = SessionHelper.SessionHelper.UserId;
            List<AssignmentModelList> assignmentModels = new List<AssignmentModelList>();
            assignmentModels = await WebAPIHelper.PendingStudentList();
            return View(assignmentModels);
        }

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
            Tasks _task = _DBContext.Tasks.FirstOrDefault(m => m.TaskID == id);
            return PartialView("_EditTask", _task);
        }


    }
}

