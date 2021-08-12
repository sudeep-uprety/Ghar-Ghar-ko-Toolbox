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
    public class UserController : Controller
    {
        UserServices _userServices = null;
        GharToolDB dbContext = new GharToolDB();
        SLogin _loginService = null;
        SOrderPlace _orderPlaceServices = null;

        public UserController()
        {
            _loginService = new SLogin();
            _userServices = new UserServices();
            _orderPlaceServices = new SOrderPlace();
        }
        // GET: User
        public ActionResult Index()
        {
            int userId = Common.UserSession.LoggedUserId;

            var vm = (from c in dbContext.UserInfo.Where(x => x.Id == userId)
                      select new UserInfoUpdateViewModal()
                      {
                          Id = c.Id,
                          Name = c.Name,
                          Address = c.Address,
                          Phone = c.Phone,
                          Remark = c.Remark,
                          ImageUrl = c.ImageUrl
                      }).FirstOrDefault();
            return View(vm);
        }

        [HttpGet]
        public ActionResult UserUpdate()
        {
            int userId = Common.UserSession.LoggedUserId;

            var vm = (from c in dbContext.UserInfo.Where(x => x.Id == userId)
                      select new UserInfoUpdateViewModal()
                      {
                          Id = c.Id,
                          Name = c.Name,
                          Address = c.Address,
                          Phone = c.Phone,
                          Remark = c.Remark,
                          ImageUrl = c.ImageUrl
                      }).FirstOrDefault();
            return View(vm);
        }

        [HttpPost]
        public ActionResult UserUpdate(UserInfoUpdateViewModal vm)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string FileName = "";
                    var upload = Request.Files[0];
                    if (upload != null && upload.ContentLength > 0)
                    {
                        FileName = Guid.NewGuid() + "." + upload.FileName.Split('.')[1]; //Path.GetFileName(upload.FileName);
                        upload.SaveAs(Server.MapPath("~/Files") + "\\" + FileName);
                    }
                    vm.ImageUrl = "/Files/" + FileName;
                }
                var data = dbContext.UserInfo.Find(Common.UserSession.LoggedUserId);
                if (data != null)
                {
                    data.Name = vm.Name;
                    data.Address = vm.Address;
                    data.Phone = vm.Phone;
                    data.Remark = vm.Remark;
                    if(!string.IsNullOrEmpty(vm.ImageUrl))
                    {
                        data.ImageUrl = vm.ImageUrl;
                    };
                    dbContext.Entry(data).State = System.Data.Entity.EntityState.Modified;
                    dbContext.SaveChanges();
                    return RedirectToAction("Index");
                };
            }
            return View(vm);
        }



        [HttpGet]
        public ActionResult Create() {

            return View();
        }
        [HttpPost]
        public ActionResult Create(UserInfoViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string FileName = "";
                    var upload = Request.Files[0];
                    if (upload != null && upload.ContentLength > 0)
                    {
                        FileName = Guid.NewGuid() + "." + upload.FileName.Split('.')[1]; //Path.GetFileName(upload.FileName);
                        upload.SaveAs(Server.MapPath("~/UserImage") + "\\" + FileName);
                    }
                    vm.ImageUrl = "/File/" + FileName;
                }
                var result = _userServices.CreateUser(vm);
                if (result != null)
                {
                    ELogin login = new ELogin()
                    {
                        Password = vm.Password,
                        UserInfoId = result.Id,
                        UserName = vm.Email,
                        Role = Role.User
                    };
                    var data = _loginService.CreateLogin(login);
                }
            }
            return View(vm);
        }



    }
}
