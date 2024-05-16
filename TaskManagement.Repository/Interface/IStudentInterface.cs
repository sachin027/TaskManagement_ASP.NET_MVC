using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.DBContext;

namespace TaskManagement.Repository.Interface
{
    public interface IStudentInterface
    {
       bool AssignmentStatus(int id);

        ///<summary> Count total number of assignments

        int TotalAssignments(string username);


        ///<summary> count total number of completed task

        int TotalCompletedAssignment(string username);

        ///<summary> count total number of pending task
        int TotalPendingAssignment(string username);

        ///<summary> Return List of completed Task
        List<Assignment> CompletedAssignmentListByStudent(int id);

        ///<summary> Return List of Pending Task
        List<Assignment> PendingAssignmentListByStudent(int id); 
    }
}
