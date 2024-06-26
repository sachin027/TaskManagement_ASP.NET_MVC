﻿using System;
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

        /// <summary>
        /// Login service for already user 
        /// check which role and validate with DB
        /// </summary>
        public bool Login(SignupCustomModel login)
        {
            try
            {
                if (login.Role == "Student")
                {
					Students student = new Students();
					student = LoginSignupHelper.ConvertSignupStudentModelToSignup(login);
					student = _DBContext.Students.Where(x => x.Username == login.Username && x.Password == login.Password).FirstOrDefault();

					if(student != null)
                    {
						return true;
                    }
					return false;
                }
                else if(login.Role == "Teacher")
                {
					Teachers teachers = new Teachers();
					teachers = LoginSignupHelper.ConvertSignupTeacherModelToSignup(login);
					teachers = _DBContext.Teachers.Where(x => x.Username == login.Username && x.Password == login.Password).FirstOrDefault();

					if(teachers != null)
                    {
						return true;
                    }
					return false;
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


		/// <summary>
		/// sign up service 
		/// check which is role is selected and then according to role save into particular table
		/// </summary>
        public bool Signup(SignupCustomModel user)
		{
			try
			{
				if (user.Role == "Student")
				{
					Students st =  LoginSignupHelper.ConvertSignupStudentModelToSignup(user);
					var isEmailExist = _DBContext.Students.Any(x => x.Email == user.Email);
					var isUserNameExist = _DBContext.Students.Any(x => x.Username == user.Username);
                    if (!isEmailExist && !isUserNameExist)
                    {
						_DBContext.Students.Add(st);
						_DBContext.SaveChanges();
						return true;
                    }
                    else
                    {
						return false;
                    }
				}
				else if (user.Role == "Teacher")
				{
					Teachers teachers =  LoginSignupHelper.ConvertSignupTeacherModelToSignup(user);
					var isEmailExist = _DBContext.Teachers.Any(x => x.Email == user.Email);
					var isUserNameExist = _DBContext.Teachers.Any(x => x.Username == user.Username);
					if (!isEmailExist && !isUserNameExist)
                    {
						_DBContext.Teachers.Add(teachers);
						_DBContext.SaveChanges();
						return true;
                    }
                    else
                    {
						return false;
                    }
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