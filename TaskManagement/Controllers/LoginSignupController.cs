﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagement.CustomFilter;
using TaskManagement.Models;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;
using TaskManagement.Repository.Interface;
using TaskManagement.Repository.Services;

namespace TaskManagement.Controllers.LoginSignup
{
    
    public class LoginSignupController : Controller
    {
        IUserPanelInterface _userPanel = new UserPanelService();

        private readonly ICityInterface _city;
        private readonly IStateInterface _state;

        public LoginSignupController()
        {
            this._city = new CityServices();
            this._state = new StateServices();

        }

        // GET: LoginSignup
        public ActionResult Index()
        {
            Session.Clear();
            return View();
        }

        [HttpPost]
        public ActionResult Index([Bind(Include ="Role ,Username , Password")] SignupCustomModel login)
        {
            try
            {
                    if (login.Username != null && login.Password!= null && login.Role == "Student" )
                    {
                        bool isValidUser = _userPanel.Login(login);
                        if (isValidUser)
                        {
                            SessionHelper.SessionHelper.Username = login.Username;

                            SessionHelper.SessionHelper.Role = login.Role;
                            TaskManagement_452Entities _DBContext = new TaskManagement_452Entities();
                            Students _student =  _DBContext.Students.FirstOrDefault(x => x.Username == login.Username);
                            int id = _student.StudentID;

                            SessionHelper.SessionHelper.UserId = id;

                            TempData["success"] = "Login successfully ";
                            return RedirectToAction("StudentDashboard", "Student");
                        }
                    }

                    else if (login.Username != null && login.Password != null && login.Role == "Teacher")
                    {
                        bool isValidUser = _userPanel.Login(login);
                        if (isValidUser)
                        {
                            SessionHelper.SessionHelper.Username = login.Username;
                            SessionHelper.SessionHelper.Role = login.Role;
                            TaskManagement_452Entities _DBContext = new TaskManagement_452Entities();
                            Teachers _teacher = _DBContext.Teachers.FirstOrDefault(x => x.Username == login.Username);
                            int id = _teacher.TeacherID;

                            SessionHelper.SessionHelper.UserId = id;
                            TempData["success"] = "Login successfully ";
                            return RedirectToAction("TeacherDashboard", "Teacher");
                        }
                    }
                
                TempData["error"] = "Login Failed !";
                return View("Index");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "LoginSignup");
            }
        }

        public ActionResult RegistrationPage()
        {
            ViewBag.States = _state.StateModelList();
            return View();
        }

        [HttpPost]
        public ActionResult RegistrationPage(SignupCustomModel signup)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if ( _userPanel.Signup(signup) == true )
                    {
                        ModelState.Clear();
                        TempData["success"] = "Register successfully ";
                        return View("Index");
                    }
                    else
                    {
                        ViewBag.States = _state.StateModelList();
                        ModelState.AddModelError("Email", "Email I'd already exist");
                        ModelState.AddModelError("Username", "Username already exist");
                        TempData["error"] = "Something went wrong ! ";
                        return View();
                    }
                }
                ViewBag.States = _state.StateModelList();
                return View();
            }
            catch (Exception ex)
            {
                return View("RegistrationPage");
            }
        }

        /// <summary>  City dropdown 
        public JsonResult CitiesByState(int id)
        {
            List<CityModel> list = _city.GetCityByStateId(id);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}