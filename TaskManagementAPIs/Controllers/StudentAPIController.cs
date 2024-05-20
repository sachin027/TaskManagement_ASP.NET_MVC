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
        private readonly IAssignTask _assignInterface;
        public StudentAPIController()
        {
            this._studentInterface = new StudentService();
            this._assignInterface = new AssignTaskService();
        }

        /// <summary> Return Completed assignment List By stundent
        [HttpGet]
        [Route("api/StudentAPI/CompletedAssignmentListByStudent")]
        public List<AssignmentModelList> CompletedAssignmentListByStudent(int id)
        {
            List<AssignmentModelList> _assignmentList = new List<AssignmentModelList>();
            _assignmentList = _studentInterface.CompletedAssignmentListByStudent(id);
            return _assignmentList;
        }

        /// <summary> Return pending assignment List By Student
        [HttpGet]
        [Route("api/StudentAPI/PendingAssignmentListByStudent")]
        public List<AssignmentModelList> PendingAssignmentListByStudent(int id)
        {
            List<AssignmentModelList> _assignmentList = new List<AssignmentModelList>();
            _assignmentList = _studentInterface.PendingAssignmentListByStudent(id);
            return _assignmentList;
        }


        ///<summary> Set assignment Status 
        [HttpPost]
        [Route("api/StudentAPI/SetAssignmentStatus")]
        public bool SetAssignmentStatus(int id)
        {
            try
            {
                bool setStatus = _studentInterface.AssignmentStatus(id);
                return setStatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary> Return all assigned task of student
        [HttpGet]
        [Route("api/StudentAPI/GetAllAssignedTask")]
        public List<AssignmentModelList> GetAllAssignedTask(int id)
        {
            List<AssignmentModelList> _assignmentList = new List<AssignmentModelList>();
            _assignmentList = _assignInterface.GetAssignmentsListById(id);
            return _assignmentList;
        }

    }
}
