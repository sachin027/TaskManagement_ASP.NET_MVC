using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.DBContext;

namespace TaskManagement.Models.ViewModel
{
    public class AssignmentModel
    {
        public int AssignmentID { get; set; }
        public Nullable<int> TaskID { get; set; }
        public string[] StudentID { get; set; }
        public virtual Students Students { get; set; }
        public virtual Tasks Tasks { get; set; }
        public Nullable<bool> status { get; set; }
    }    
    
    public class AssignmentModelList
    {
        public int AssignmentID { get; set; }
        public Nullable<int> TaskID { get; set; }
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string TaskName { get; set; }
        public string TeacherName { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public Nullable<bool> status { get; set; }
    }
}
