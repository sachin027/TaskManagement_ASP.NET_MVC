using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagement.Models;
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
                if (_userPanel.Login(login))
                {

                    SessionHelper.SessionHelper.Username = login.Username;

                    if(login.Role == "Student") { 
                        return RedirectToAction("StudentDashboard","Student");
                        TempData["success"] = "Login successfully ";
                    }
                    else
                    {
                        TempData["success"] = "Login successfully ";
                        return RedirectToAction("TeaacherDashboard","Teacher");
                    }
                }
                else
                {
                    TempData["error"] = "Login Failed !";
                    return RedirectToAction("Index", "LoginSignup");
                }
            }
            catch (Exception ex)
            {

                throw ex;
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
                if (_userPanel.Signup(signup) == true)
                {
                    TempData["success"] = "Register successfully ";
                    return View("Index");
                }
                else
                {
                    return View();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// City dropdown 
        /// </summary>
        public JsonResult CitiesByState(int id)
        {
            List<CityModel> list = _city.GetCityByStateId(id);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}