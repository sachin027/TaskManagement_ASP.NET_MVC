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
            List<AssignmentModelList> _taskList = new List<AssignmentModelList>();
            //ViewBag.TotalCreatedTaskByTeacher = _task.TotalCreatedTaskByTeacher(name);
            ViewBag.TotalCreatedTaskByTeacher = _task.GetCustomTaskList(name).Count();
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
        public async Task<ActionResult> CreateTask(TaskModel customTaskModel)
        {
            try
            {
                if (customTaskModel != null && ModelState.IsValid)
                {
                    /*_addTask.AddTask(customTaskModel);*/

                    bool ans = await WebAPIHelper.CreateTask(customTaskModel);
                    if (ans)
                    {
                        TempData["success"] = "Task added successfully";
                        return RedirectToAction("TeacherDashboard");
                    }
                    else
                    {
                        return View("CreateTask");
                    }
                    
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
            ViewBag.TaskId = id;
            List<StudentModel> _studentList = new List<StudentModel>();
            _studentList = _task.GetStudentListById(id);
            ViewBag._studentlist = _studentList;
            AssignmentModel assignmentModel = new AssignmentModel();
            return PartialView("_AssignTask",assignmentModel);
        }

        [HttpPost]
        public async Task<ActionResult> AssignTask([Bind(Exclude = "status,Tasks,Students")] AssignmentModel assignmentModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    bool isSaving = await WebAPIHelper.AssignTask(assignmentModel);

                    if (isSaving)
                    {
                        TempData["success"] = "Task assign successfully";
                        return RedirectToAction("TeacherDashboard");
                    }
                }
                List<StudentModel> _studentList = new List<StudentModel>();
                _studentList = _task.GetStudentListById(assignmentModel.TaskID);
                ViewBag._studentlist = _studentList;

                TempData["error"] = "Something wrong";
                return PartialView("_AssignTask",assignmentModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary> redirect to all task list page which created by teacher .
        public async Task<ActionResult> TaskList(int? pageNumber)
        {
            List<CustomTaskModel> _taskList = new List<CustomTaskModel>();
            string username = SessionHelper.SessionHelper.Username;
            _taskList = await WebAPIHelper.GetCustomTaskList();

            int page = pageNumber ?? 1;

           var _pagination = PaginatedList<CustomTaskModel>.Pagination(_taskList, page);

            ViewBag.totalCount = PaginatedList<CustomTaskModel>.totalCount;
            ViewBag.page = PaginatedList<CustomTaskModel>.page;
            ViewBag.pageSize = PaginatedList<CustomTaskModel>.pageSize;
            ViewBag.totalPage = PaginatedList<CustomTaskModel>.totalPage;

            return View(_pagination);
            //return View(_taskList);
        }

        /// <summary> Get all task assigned student List
        public async Task<ActionResult> GetAllTaskAssignedStudentList(int? pageNumber)
        {
            int id = SessionHelper.SessionHelper.UserId;
            List<AssignmentModelList> assignmentModels = new List<AssignmentModelList>();
            assignmentModels = await WebAPIHelper.GetAllTaskAssignedStudentList();

            int page = pageNumber ?? 1;
            var _pagination = PaginatedList<AssignmentModelList>.Pagination(assignmentModels, page);
            ViewBag.totalCount = PaginatedList<AssignmentModelList>.totalCount;
            ViewBag.page = PaginatedList<AssignmentModelList>.page;
            ViewBag.pageSize = PaginatedList<AssignmentModelList>.pageSize;
            ViewBag.totalPage = PaginatedList<AssignmentModelList>.totalPage;

            return View(_pagination);
        }

        /// <summary> Get all completed task student list
        public async Task<ActionResult> CompletedStudentList(int? pageNumber)
        {
            int id = SessionHelper.SessionHelper.UserId;
            List<AssignmentModelList> assignmentModels = new List<AssignmentModelList>();
            assignmentModels = await WebAPIHelper.CompletedStudentList();

            int page = pageNumber ?? 1;

            var _pagination = PaginatedList<AssignmentModelList>.Pagination(assignmentModels, page);

            ViewBag.totalCount = PaginatedList<AssignmentModelList>.totalCount;
            ViewBag.page = PaginatedList<AssignmentModelList>.page;
            ViewBag.pageSize = PaginatedList<AssignmentModelList>.pageSize;
            ViewBag.totalPage = PaginatedList<AssignmentModelList>.totalPage;
            return View(_pagination);
        }

        /// <summary> Get all pending task student list
        public async Task<ActionResult> PendingStudentList(int? pageNumber)
        {
            int id = SessionHelper.SessionHelper.UserId;
            List<AssignmentModelList> assignmentModels = new List<AssignmentModelList>();
            assignmentModels = await WebAPIHelper.PendingStudentList();

            int page = pageNumber ?? 1;

            var _pagination = PaginatedList<AssignmentModelList>.Pagination(assignmentModels, page);

            ViewBag.totalCount = PaginatedList<AssignmentModelList>.totalCount;
            ViewBag.page = PaginatedList<AssignmentModelList>.page;
            ViewBag.pageSize = PaginatedList<AssignmentModelList>.pageSize;
            ViewBag.totalPage = PaginatedList<AssignmentModelList>.totalPage;
            return View(_pagination);
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

