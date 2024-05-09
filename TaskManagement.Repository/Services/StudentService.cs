using System;
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
    }
}
