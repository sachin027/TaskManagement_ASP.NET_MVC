using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;

namespace TaskManagement.Helper.LoginSignupHelper
{
    public class LoginSignupHelper
    {
        public static Students ConvertSignupStudentModelToSignup(SignupCustomModel signup)
        {
            try
            {
                Students student = new Students();
                if (signup != null)
                {
                    student.Username = signup.Username;
                    student.Email = signup.Email;
                    student.Password = signup.Password;
                    student.Address = signup.Address;
                    student.ContactNumber = signup.PhoneNumber;
                    student.CityID = signup.CityID;
                    student.StateID = signup.StateID;
                }
                return student;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static Teachers ConvertSignupTeacherModelToSignup(SignupCustomModel signup)
        {
            try
            {
                Teachers teacher = new Teachers();
                if (signup != null)
                {
                    teacher.Username = signup.Username;
                    teacher.Email = signup.Email;
                    teacher.Password = signup.Password;
                    teacher.Address = signup.Address;
                    teacher.ContactNumber = signup.PhoneNumber;
                    teacher.StateID = signup.StateID;
                    teacher.CityID = signup.CityID;
                }
                return teacher;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
