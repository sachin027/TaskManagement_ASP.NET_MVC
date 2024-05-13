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

        /// <summary> Get task List
        List<TaskModel> GetTaskList(string username);

        /// <summary> Assign Task
        bool AssignTaskToStudent(AssignmentModel assignment);

        /// <summary>  Get Assignment List
        List<Assignment> GetAssignmentsListById(string userName);

        /// <summary> Get Total Number of Created Assignment by Teacher
        int TotalCreatedTaskByTeacher( string username);     
        
        /// <summary> Get Total Number of Task Assigned Students
        int TotalTaskAssignedToStudent( string username);        

        /// <summary> Get Total Number of Task Complete by Students
        int TotalCompletedTaskByStudent( string username);        

        /// <summary> Get Total Number of Task Pending by Students
        int TotalPendingTaskByStudent( string username);



    }
}
