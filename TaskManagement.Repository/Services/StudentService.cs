﻿ using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.DBContext;
using TaskManagement.Repository.Interface;

namespace TaskManagement.Repository.Services
{
    public class StudentService : IStudentInterface
    {
        TaskManagement_452Entities _DBContext = new TaskManagement_452Entities();
        public bool AssignmentStatus(int id)
        {
            try
            {
                Assignment assignments = new Assignment();
                assignments = _DBContext.Assignment.FirstOrDefault(m => m.AssignmentID == id);

                int isUpdateSaveOrNot = 0;
                if (assignments.status != Convert.ToBoolean(1))
                {
                    assignments.status = Convert.ToBoolean(1);
                    _DBContext.Entry(assignments).State = EntityState.Modified;
                    isUpdateSaveOrNot = _DBContext.SaveChanges();
                }

                if (isUpdateSaveOrNot > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
            students = _DBContext.Students.FirstOrDefault(u => u.Username == username);
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

        ///<summary> count total number of completed task
        public int TotalCompletedAssignment(string username)
        {
            int TotalCompleteAssignment = 0;
            TaskManagement_452Entities _DBContext = new TaskManagement_452Entities();
            Students students = new Students();
            students = _DBContext.Students.FirstOrDefault(x => x.Username == username);
            int SId = students.StudentID;

            try
            {
                List<Assignment> _assignmentList = _DBContext.Assignment.Where(x => x.StudentID == SId && x.status == true).ToList();
                TotalCompleteAssignment = _assignmentList.Count();
                return TotalCompleteAssignment;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        ///<summary> count total number of pending task
        public int TotalPendingAssignment(string username)
        {
            int TotalPendingAssignment = 0;
            TaskManagement_452Entities _DBContext = new TaskManagement_452Entities();
            Students students = new Students();
            students = _DBContext.Students.FirstOrDefault(x => x.Username == username);
            int SId = students.StudentID;

            try
            {
                List<Assignment> _assignmentList = _DBContext.Assignment.Where(x => x.StudentID == SId && x.status == false).ToList();
                TotalPendingAssignment = _assignmentList.Count();
                return TotalPendingAssignment;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
