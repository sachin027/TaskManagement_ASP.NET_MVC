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
        /// <summary>  Get student List for assign task
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

        /// <summary> Get task list of specific teacher
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

        /// <summary> Assign task to particular selected students
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

        /// <summary> Return all assign Task List by all teachers     
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

        /// <summary> Get Total Number of Created Assignment by Teacher
        public int TotalCreatedTaskByTeacher(string username)
        {
            TaskManagement_452Entities _DBContext = new TaskManagement_452Entities();
            try
            {
                int TotalCreatedTask = 0;
                List<Tasks> _taskList = _DBContext.Tasks.Where(m => m.Teachers.Username == username).ToList();

                if(_taskList != null)
                {
                    TotalCreatedTask = _taskList.Count();
                }
                 return TotalCreatedTask;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary> Get Total Number of Task Assigned Students
        public int TotalTaskAssignedToStudent(string username)
        {
            TaskManagement_452Entities _DBContext = new TaskManagement_452Entities();
            try
            {
                int TotalTaskAssignToStudent = 0;
                Teachers teachers = _DBContext.Teachers.Where(x => x.Username == username).FirstOrDefault();
                int TeacherId = Convert.ToInt32( teachers.TeacherID);

                List<Assignment> _assignmentList = _DBContext.Assignment.Where(m=>m.Tasks.CreatorID == TeacherId).ToList();

                if (_assignmentList != null)
                {
                    TotalTaskAssignToStudent = _assignmentList.Count();
                }
                return TotalTaskAssignToStudent;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary> Get Total Number of Task Complete by Students
        public int TotalCompletedTaskByStudent(string username)
        {
            TaskManagement_452Entities _DBContext = new TaskManagement_452Entities();
            try
            {
                int TotalCompletedTaskByStudent = 0;
                Teachers teachers = _DBContext.Teachers.Where(x => x.Username == username).FirstOrDefault();
                int TeacherId = Convert.ToInt32(teachers.TeacherID);

                List<Assignment> _assignmentList = _DBContext.Assignment.Where(m => m.Tasks.CreatorID == TeacherId && m.status == true).ToList();

                if (_assignmentList != null)
                {
                    TotalCompletedTaskByStudent = _assignmentList.Count();
                }
                return TotalCompletedTaskByStudent;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary> Get List of Task Complete by Students
        public List<Assignment> TotalCompletedTaskByStudentList(int id)
        {
            try
            {
                TaskManagement_452Entities _DBContext = new TaskManagement_452Entities();
                List<Assignment> _assignmentList = _DBContext.Assignment.Where(u => u.Tasks.CreatorID == id && u.status== true).ToList();
                if(_assignmentList != null)
                {
                    return _assignmentList;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary> Get Total Number of Task Pending by Students
        public int TotalPendingTaskByStudent(string username)
        {
            TaskManagement_452Entities _DBContext = new TaskManagement_452Entities();
            try
            {
                int TotalPendingTaskByStudent = 0;
                Teachers teachers = _DBContext.Teachers.Where(x => x.Username == username).FirstOrDefault();
                int TeacherId = Convert.ToInt32(teachers.TeacherID);

                List<Assignment> _assignmentList = _DBContext.Assignment.Where(m => m.Tasks.CreatorID == TeacherId && m.status == false).ToList();

                if (_assignmentList != null)
                {
                    TotalPendingTaskByStudent = _assignmentList.Count();
                }
                return TotalPendingTaskByStudent;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary> Get List of Task Pending by Students
        public List<Assignment> TotalPendingTaskByStudentList(int id)
        {
            try
            {
                TaskManagement_452Entities _DBContext = new TaskManagement_452Entities();
                List<Assignment> _assignmentList = _DBContext.Assignment.Where(u => u.Tasks.CreatorID == id && u.status== false).ToList();
                if(_assignmentList != null)
                {
                    return _assignmentList;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Get Student List of those who have not received any Task
        public List<StudentModel> GetStudentListById(int id)
        {
            TaskManagement_452Entities _DBContext = new TaskManagement_452Entities();
            try
            {
                List<StudentModel> _studentList = new List<StudentModel>();
                List<Students> student = _DBContext.Students.Where(x => !x.Assignment.Any(y => y.TaskID == id)).ToList();
                _studentList = StudentHelper.GetStudentListByHelper(student);
                return _studentList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
