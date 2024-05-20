using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;

namespace TaskManagement.Repository.Interface
{
    public interface IAssignTask
    {
        /// <summary>  Get student List
        List<StudentModel> GetStudentList();

        ///<summary> Get student list By task Id
        List<StudentModel> GetStudentListById(int? id);

        /// <summary> Get task List
        List<TaskModel> GetTaskList(string username);

        List<CustomTaskModel> GetCustomTaskList(string username);

        /// <summary> Return all Assigned Task student List
        List<AssignmentModelList> GetAllTaskAssignedStudentList(int id);

        /// <summary> Assign Task
        bool AssignTaskToStudent(AssignmentModel assignment);

        /// <summary>  Return all  Assignment List For Students
        List<AssignmentModelList> GetAssignmentsListById(int id);

        /// <summary> Get Total Number of Created Assignment by Teacher
        int TotalCreatedTaskByTeacher( string username);     
        
        /// <summary> Get Total Number of Task Assigned Students
        int TotalTaskAssignedToStudent( string username);        

        /// <summary> Get Total Number of Task Complete by Students
        int TotalCompletedTaskByStudent( string username);

        /// <summary> Return List of Task Complete by Students
        List<AssignmentModelList> TotalCompletedTaskByStudentList(int id);

        /// <summary>Return List of Task Pending by Students
        List<AssignmentModelList> TotalPendingTaskByStudentList(int id);

        /// <summary> Get Total Number of Task Pending by Students
        int TotalPendingTaskByStudent( string username);
    }
}
