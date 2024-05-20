using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManagement.Models.ViewModel;
using TaskManagement.Repository.Interface;
using TaskManagement.Repository.Services;

namespace TaskManagementAPIs.Controllers
{
    public class TeacherAPIController : ApiController
    {
        private readonly IAssignTask _Assigntask;
        private readonly IAddTask _addTask;

        /// <summary> Constructor
        public TeacherAPIController()
        {
            this._Assigntask = new AssignTaskService();
            this._addTask = new AddTaskService();
        }

        /// <summary> Return all task assigned student List
        [HttpGet]
        [Route("api/TeacherAPI/GetAllTaskAssignedStudentList")]
        public List<AssignmentModelList> GetAllTaskAssignedStudentList(int id)
        {
            List<AssignmentModelList> _taskList = new List<AssignmentModelList>();
            _taskList = _Assigntask.GetAllTaskAssignedStudentList(id);
            return _taskList;
        }

        /// <summary> Return Completed assignment  student List
        [HttpGet]
        [Route("api/TeacherAPI/AList")]
        public List<AssignmentModelList> AList(int id)
        {
            List<AssignmentModelList> _assignmentList = new List<AssignmentModelList>();
            _assignmentList = _Assigntask.TotalCompletedTaskByStudentList(id);
            return _assignmentList;
        }

        /// <summary> Return pending  assignment student List
        [HttpGet]
        [Route("api/TeacherAPI/GetPendingTaskStudentList")]
        public List<AssignmentModelList> GetPendingStudentList(int id)
        {
            List<AssignmentModelList> _assignmentList = new List<AssignmentModelList>();
            _assignmentList = _Assigntask.TotalPendingTaskByStudentList(id);
            return _assignmentList;
        }

        /// <summary> Return all assignment List
        [HttpGet]
        [Route("api/TeacherAPI/GetCustomTaskList")]
        public List<CustomTaskModel> GetCustomTaskList(string username)
        {
            List<CustomTaskModel> _taskModel = new List<CustomTaskModel>();
            _taskModel = _Assigntask.GetCustomTaskList(username);
            return _taskModel;
        }

        /// <summary> Create Task
        [HttpPost]
        [Route("api/TeacherAPI/CreateTask")]
        public bool CreateTask(TaskModel task)
        {
            try
            { 
                bool checkSave = _addTask.AddTask(task);
                return checkSave;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary> Assign Task
        [HttpPost]
        [Route("api/TeacherAPI/AssignTask")]
        public bool AssignTask(AssignmentModel assign)
        {
            try
            { 
                bool checkSave = _Assigntask.AssignTaskToStudent(assign);
                return checkSave;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
