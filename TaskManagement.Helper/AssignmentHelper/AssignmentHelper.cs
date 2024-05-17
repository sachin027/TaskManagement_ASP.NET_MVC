using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;

namespace TaskManagement.Helper.AssignmentHelper
{
    public class AssignmentHelper
    {
        public static List<AssignmentModelList> ConvertDBAssignmentListToAssignmentModelList(List<Assignment> assignments)
        {
            List<AssignmentModelList> assignmentModelLists = new List<AssignmentModelList>();
            if (assignments != null)
            {
                foreach (var item in assignments)
                {
                    AssignmentModelList assignmentModel = new AssignmentModelList();
                    assignmentModel.AssignmentID = item.AssignmentID;
                    assignmentModel.StudentID = item.Students.StudentID;
                    assignmentModel.TaskID = item.TaskID;
                    assignmentModel.status = item.status;
                    assignmentModel.StudentName = item.Students.Username;
                    assignmentModel.TaskName = item.Tasks.TaskName;
                    assignmentModel.Description = item.Tasks.Description;
                    assignmentModel.Deadline = (DateTime)item.Tasks.Deadline;
                    assignmentModelLists.Add(assignmentModel);
                }
            }
            return assignmentModelLists;
        }
    }
}
