using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;
using TaskManagement.Repository.Interface;

namespace TaskManagement.Repository.Services
{
    public class TeacherService : ITeacherInterface
    {
        TaskManagement_452Entities _DBContext = new TaskManagement_452Entities();
        public Teachers GetTeacherByUsername(string username)
        {
            try
            {
                Teachers _teacher = new Teachers();
                _teacher = _DBContext.Teachers.FirstOrDefault(x=>x.Username == username);
                return _teacher;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
