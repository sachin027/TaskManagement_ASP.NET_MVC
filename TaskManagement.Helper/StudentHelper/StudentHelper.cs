using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;

namespace TaskManagement.Helper.StudentHelper
{
    public class StudentHelper
    {
        public static List<StudentModel> GetStudentListByHelper(List<Students> studentList)
        {
            List<StudentModel> _studentModels = new List<StudentModel>();

            try
            {
                if(studentList != null && studentList.Count > 0)
                {
                    foreach (Students Student in studentList)
                    {
                        StudentModel st = new StudentModel();

                        st.StudentID = Student.StudentID;
                        st.Username = Student.Username;
                        st.Email = Student.Email;
                        st.Password = Student.Password;
                        st.Address = Student.Address;
                        st.ContactNumber = Student.ContactNumber;
                        st.CityID = Student.CityID;
                        st.StateID = Student.StateID;
                        _studentModels.Add(st);
                    }
                }
                return _studentModels;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
