using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;

namespace TaskManagement.Repository.Interface.LoginSignupInterface
{
    public interface ILoginSignupInterface
    {

        ///<summary>
        ///Registration of new user
        /// </summary>
        Students RegisterStudent(StudentModel studentModel);

        ///<summary>
        ///Login new user
        /// </summary>
        // bool LoginUser(LoginModel login);
    }
}