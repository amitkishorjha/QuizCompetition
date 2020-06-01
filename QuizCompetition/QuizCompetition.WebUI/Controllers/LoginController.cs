using School.BusinessLogic.Impl;
using School.BusinessLogic.Interface;
using School.Repository.Common;
using School.Repository.Impl;
using School.WebUI.SMHS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.WebUI.SMHS.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _UserService;

        public LoginController()
        {
            this._UserService = new UserService(new UserRepository<EFDbContext>());
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LoginViewModel model)
        {
            var user = _UserService.GetAll().Where(x => x.Email == model.Email && x.Password == model.Password);
            if (user.Any())
            {
                var userEntity = user.FirstOrDefault();

                //ViewBag.ProfileModel = new ProfileViewModel() { Designation = userEntity.IsSuperUser ? "Super Admin" : "Admin|Teacher", User = userEntity };
                _UserService.UpdateLastLogin(userEntity.Id);
                _UserService.Save();

                System.Web.Security.FormsAuthentication.SetAuthCookie(userEntity.Id.ToString(), model.RememberMe);
                Session["user"] = userEntity;
                //Session["user"] = new ProfileViewModel() { Designation = userEntity.IsSuperUser ? "Super Admin" : "Admin|Teacher", User = userEntity };
                if (string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                {
                    return RedirectToAction("Index", "Gallery");
                }
                else
                {
                    Response.Redirect(Request.QueryString["ReturnUrl"]);

                }
            }
            else
            {
                ModelState.AddModelError("LoginError", "Please Enter Correct username and password");
            }
            return View();
        }

        public ActionResult LogOut()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("LogIn");
        }
    }
}