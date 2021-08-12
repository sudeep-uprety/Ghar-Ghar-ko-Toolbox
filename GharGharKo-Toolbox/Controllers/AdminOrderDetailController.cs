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
    public class AdminOrderDetailController : Controller
    {

        SOrderPlace _orderPlace = null;
        SProfessional _professional = null;
        SService _service = null;
        GharToolDB dbContext = null;
        public AdminOrderDetailController()
        {
            dbContext = new GharToolDB();
            _orderPlace = new SOrderPlace();
            _professional = new SProfessional();
            _service = new SService();
        }
        // GET: AdminOrderDetail

        public ActionResult Home() {
            if (Common.UserSession.UserInfoViewModel == null)
            {

                return RedirectToAction("Index", "Login");
            }
            if (Common.UserSession.UserInfoViewModel.Role != DB.Role.Admin)
            {

                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult Index()
        {
            if (Common.UserSession.UserInfoViewModel == null)
            {

                return RedirectToAction("Index", "Login");
            }
            if (Common.UserSession.UserInfoViewModel.Role != DB.Role.Admin)
            {

                return RedirectToAction("Index", "Home");
            }

            var result = _orderPlace.GetOrderDetails();
            return View(result);
        }

        public ActionResult UsersList()
        {
            var result = (from c in dbContext.UserInfo.ToList()
                          select new UsersListViewModel()
                          {
                              Id = c.Id,
                              Name = c.Name,
                              Address = c.Address,
                              Phone = c.Phone,
                              Remark = c.Remark,
                              Email = c.Email,
                              ImageUrl = c.ImageUrl
                          }).ToList();
            return View(result);
        }

        public ActionResult DeleteUser(int id)
        {
            if(id != 0)
            {
                var data = dbContext.UserInfo.Find(id);
                if(data != null)
                {
                    dbContext.UserInfo.Remove(data);
                    dbContext.SaveChanges();
                }
            }
            return RedirectToAction("UsersList");
        }
        public ActionResult ServicesList()
        {
            if (Common.UserSession.UserInfoViewModel == null)
            {

                return RedirectToAction("Index", "Login");
            }
            if (Common.UserSession.UserInfoViewModel.Role != DB.Role.Admin)
            {

                return RedirectToAction("Index", "Home");
            }
            var result = _service.ReadList();
            return View(result);
        }

        public ActionResult Completed(int Id) {
            if (Common.UserSession.UserInfoViewModel == null)
            {

                return RedirectToAction("Index", "Login");
            }
            if (Common.UserSession.UserInfoViewModel.Role != DB.Role.Admin)
            {

                return RedirectToAction("Index", "Home");
            }
            var data = _orderPlace.OrderDelivered(Id);
            return RedirectToAction("Index");
        }
        public ActionResult Professional() {

            if (Common.UserSession.UserInfoViewModel == null)
            {

                return RedirectToAction("Index", "Login");
            }
            if (Common.UserSession.UserInfoViewModel.Role != DB.Role.Admin)
            {

                return RedirectToAction("Index", "Home");
            }
            var result = _professional.ReadList();
            return View(result);
        }
    }
}