using GharToolBax.DB;
using GharToolBax.Services;
using GharToolBax.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GharToolBax.Controllers
{
    public class LoginController : Controller
    {

        SLogin sLogin = null;

        public LoginController()
        {
            sLogin = new SLogin();

        }
        public ActionResult Index()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {

                var data = sLogin.UserInfoList().Where(x => x.Email == model.UserName.Trim() && x.Password == model.Password).FirstOrDefault();
                if (data == null)
                {
                    ModelState.AddModelError("Password", "Invalid Login !");
                    return View(model);
                }


                Common.UserSession.LoggedUserId = data.Id;
                Common.UserSession.UserInfoViewModel = data;

                switch (data.Role)
                {
                    case Role.Admin:
                        return RedirectToAction("Home", "AdminOrderDetail");
                    case Role.Professional:
                        break;
                        return RedirectToAction("Home", "AdminOrderDetail");
                    case Role.User:
                        return RedirectToAction("Index", "Home");

                }
            }
            return View(model);
        }

        public ActionResult LogOut(LoginViewModel model)
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }



    }
}