using GharToolBax.Services;
using GharToolBax.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;

namespace GharToolBax.Controllers
{
    public class ServiceController : Controller
    {
        SService _service = null;
        public ServiceController()
        {
            _service = new SService();
        }
        // GET: Service
        public ActionResult Index()
        {

            if (Common.UserSession.UserInfoViewModel == null)
            {

                return RedirectToAction("Index", "Login");
            }
            if (Common.UserSession.UserInfoViewModel.Role  != DB.Role.Admin)
            {
                return Redirect("/Home");
            }
            var vm = _service.ReadList();
            return View(vm);
        }

        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateService(ServiceViewModel vm)
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
                _service.CreateService(vm);
                return Redirect("/AdminOrderDetail/ServicesList");
            }
            return View(vm);
            
        }

        public ActionResult DeleteService(int id)
        {

            if (Common.UserSession.UserInfoViewModel == null)
            {

                return RedirectToAction("Index", "Login");
            }
            if (Common.UserSession.UserInfoViewModel.Role != DB.Role.Admin)
            {
                return Redirect("/Home");
            }
            if (id != 0)
            {
                _service.DeleteService(id);
                return Redirect("/AdminOrderDetail/ServicesList");
            }
            return RedirectToAction("Index");
        }
        [HttpGet]

        public ActionResult Update(int id)
        {

          
            var vm = _service.GetUpdateService(id);
            return View(vm);
        }






        [HttpPost]
        public ActionResult Update(ServiceUpdateViewModel vm)
        {
            if(vm!= null)
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
                _service.UpdateService(vm);
                return Redirect("/AdminOrderDetail/ServicesList");
            }
            
            return RedirectToAction("Index");
        }


        }
}