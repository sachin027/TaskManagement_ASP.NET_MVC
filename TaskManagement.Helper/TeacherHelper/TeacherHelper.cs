using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;

namespace TaskManagement.Helper.TeacherHelper
{
    public class TeacherHelper
    {
        public static Teachers ConvertTeacherModelToTeacherContext(TeacherModel _teacherModel)
        {
            Teachers _teachers = new Teachers();

            if (_teacherModel != null)
            {
                _teachers.TeacherID = _teacherModel.TeacherID;
                _teachers.Username = _teacherModel.Username;
                _teachers.Email = _teacherModel.Email;
                _teachers.Password = _teacherModel.Password;
                _teachers.Address = _teacherModel.Address;
                _teachers.ContactNumber = _teacherModel.ContactNumber;
                _teachers.StateID = _teacherModel.StateID;
                _teachers.CityID = _teacherModel.CityID;
            }

            return _teachers;
        }


    }
}
