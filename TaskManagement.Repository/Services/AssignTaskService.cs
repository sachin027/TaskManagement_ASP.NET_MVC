using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Helper.StudentHelper;
using TaskManagement.Helper.TaskHelper;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;
using TaskManagement.Repository.Interface;

namespace TaskManagement.Repository.Services
{
    public class AssignTaskService : IAssignTask
    {
        /// <summary>
        /// Get student List for assign task
        /// </summary>
        public List<StudentModel> GetStudentList()
        {
            TaskManagement_452Entities _DBContext = new TaskManagement_452Entities();
            try
            {
                List<StudentModel> _studentList = new List<StudentModel>();
                List<Students> student = _DBContext.Students.ToList();
                _studentList = StudentHelper.GetStudentListByHelper(student);
                return _studentList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get task list of specific teacher
        /// </summary>
        public List<TaskModel> GetTaskList(string username)
        {
            TaskManagement_452Entities _DBContext = new TaskManagement_452Entities();
            try
            {
                List<TaskModel> _taskList = new List<TaskModel>();
                List<Tasks> task = _DBContext.Tasks.Where(m => m.Teachers.Username == username).ToList();

                _taskList = TaskHelper.GetTaskListByHelper(task);
                return _taskList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Assign task to particular selected students
        /// </summary>

        public bool AssignTaskToStudent(AssignmentModel assignmentModel)
        {
            try
            {
                TaskManagement_452Entities _DBContext = new TaskManagement_452Entities();
                Assignment assignment = new Assignment();
                assignment.TaskID = assignmentModel.TaskID;

                foreach (var item in assignmentModel.StudentID)
                {
                    int isCheckingSaveOrNot = 0;
                    assignment.StudentID = Convert.ToInt32(item);
                    assignment.status = false;
                    _DBContext.Assignment.Add(assignment);
                    isCheckingSaveOrNot = _DBContext.SaveChanges();

                    if (isCheckingSaveOrNot <= 0)
                    {
                        return false;
                    }

                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// Return all assign Task List by all teachers
        /// </summary>
        
        public List<Assignment> GetAssignmentsListById(string userName)
        {
            TaskManagement_452Entities _DBContext = new TaskManagement_452Entities();
            try
            {
                Students _student = new Students();
                _student = _DBContext.Students.FirstOrDefault(x=>x.Username==userName);
                int id = _student.StudentID;
                List<Assignment> _assignmentList = _DBContext.Assignment.Where(u => u.StudentID == id).ToList();

                return _assignmentList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>Count assignment service
        public int TotalAssignments(string username)
        {
            int TotalCount = 0;
            Students students = new Students();
            
            TaskManagement_452Entities _DBContext = new TaskManagement_452Entities();
            students = _DBContext.Students.FirstOrDefault(u=>u.Username== username);
            int id = students.StudentID;

            try
            {
                List<Assignment> _assignmentList = _DBContext.Assignment.Where(u => u.StudentID == id).ToList();
                TotalCount = _assignmentList.Count();
                return TotalCount;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
