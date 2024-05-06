using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Helper.LoginSignupHelper;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;
using TaskManagement.Repository.Interface;

namespace TaskManagement.Repository.Services
{

	public class UserPanelService : IUserPanelInterface
	{
	 TaskManagement_452Entities _DBContext = new TaskManagement_452Entities();
		public bool Signup(SignupCustomModel user)
		{
			try
			{
				if (user.Role == "Student")
				{
					Students st =  LoginSignupHelper.ConvertSignupStudentModelToSignup(user);
					// var isEmailExist = _DBContext.Students.Any(x => x.Email == user.Email);

					_DBContext.Students.Add(st);
					_DBContext.SaveChanges();
					return true;
				}
				else
				{
					Teachers teachers =  LoginSignupHelper.ConvertSignupTeacherModelToSignup(user);
					_DBContext.Teachers.Add(teachers);
					_DBContext.SaveChanges();
					return true;
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
	}
}