using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManagement.Helper.TaskHelper;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;
using TaskManagement.Repository.Interface;
using TaskManagement.Repository.Services;

namespace TaskManagementAPIs.Controllers
{
    public class StudentAPIController : ApiController
    {
        private readonly IStudentInterface _studentInterface;
        private readonly IAssignTask _assignTask;
        TaskManagement_452Entities _DBContext = new TaskManagement_452Entities();
        public StudentAPIController()
        {
            this._assignTask = new AssignTaskService();
            this._studentInterface = new StudentService();
        }

        [HttpGet]
        [Route("api/StudentAPI/GetAllTaskAssignedStudentList")]
        public List<AssignmentModelList> GetAllTaskAssignedStudentList(int id)
        {
            List<AssignmentModelList> _taskList = new List<AssignmentModelList>();
            _taskList = _assignTask.GetAllTaskAssignedStudentList(id);
            return _taskList;
        }


        [HttpGet]
        [Route("api/StudentAPI/AList")]
        public List<AssignmentModelList> AList(int id)
        {
            List<AssignmentModelList> _assignmentList = new List<AssignmentModelList>();
            _assignmentList = _assignTask.TotalCompletedTaskByStudentList(id);
            return _assignmentList;
        }

        [HttpGet]
        [Route("api/StudentAPI/GetPendingTaskStudentList")]
        public List<AssignmentModelList> GetPendingStudentList(int id)
        {
            List<AssignmentModelList> _assignmentList = new List<AssignmentModelList>();
            _assignmentList = _assignTask.TotalPendingTaskByStudentList(id);
            return _assignmentList;
        }

        [HttpGet]
        [Route("api/StudentAPI/CompletedAssignmentListByStudent")]
        public List<AssignmentModelList> CompletedAssignmentListByStudent(int id)
        {
            List<AssignmentModelList> _assignmentList = new List<AssignmentModelList>();
            _assignmentList = _studentInterface.CompletedAssignmentListByStudent(id);
            return _assignmentList;
        }        
        
        [HttpGet]
        [Route("api/StudentAPI/PendingAssignmentListByStudent")]
        public List<AssignmentModelList> PendingAssignmentListByStudent(int id)
        {
            List<AssignmentModelList> _assignmentList = new List<AssignmentModelList>();
            _assignmentList = _studentInterface.PendingAssignmentListByStudent(id);
            return _assignmentList;
        }
    }
}
