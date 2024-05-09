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
        /// <summary>
        /// Get student List
        /// </summary>
        List<StudentModel> GetStudentList();

        /// <summary>
        /// Get task List
        /// </summary>
        List<TaskModel> GetTaskList(string username);

        /// <summary>
        /// Assign Task
        /// </summary>

        bool AssignTaskToStudent(AssignmentModel assignment);


        /// <summary>
        /// Get Assignment List
        /// </summary>

        List<Assignment> GetAssignmentsListById(string userName);

        ///<summary> Count total number of assignments

        int TotalAssignments(string username);

    }
}
