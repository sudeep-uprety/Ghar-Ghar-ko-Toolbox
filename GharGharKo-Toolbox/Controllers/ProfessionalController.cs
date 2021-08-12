  using GharToolBax.DB;
using GharToolBax.Services;
using GharToolBax.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GharToolBax.Controllers
{

    public class ProfessionalController : Controller
    {

        SProfessional _sProfessional = null;
        SLogin _loginServices = new SLogin();
        public ProfessionalController()
        {
            _sProfessional = new SProfessional();
            _loginServices = new SLogin();
        }
        // GET: Professional
        public ActionResult Index()
        {

            if (Common.UserSession.UserInfoViewModel == null)
            {

                return RedirectToAction("Index", "Login");
            }
            if (Common.UserSession.UserInfoViewModel.Role != DB.Role.Admin)
            {
                return Redirect("/Home");
            }
            var vm = _sProfessional.ReadList();
            return View(vm);
        }

        [HttpGet]
        public ActionResult CreateProfessional()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateProfessional(UserInfoViewModel sm)
        {
            if (ModelState.IsValid)
            {
                var result = _sProfessional.CreateProfessional(sm);
                ELogin login = new ELogin()
                {
                    Password = sm.Password,
                    UserInfoId = result.Id,
                    UserName = sm.Email,
                    Role = Role.Professional,

                };

                var data = _loginServices.CreateLogin(login);
                return RedirectToAction("Professional", "AdminOrderDetail");
            }
            return View(sm);
        }

        public ActionResult ProfessionalList(int? id)
        {


            var vm = _sProfessional.ReadList();

            return View(vm);
        }
        public ActionResult HomeSewaView(int ServiceId, string ServiceName = "")
        {


            Common.UserSession.ServiceId = ServiceId;
            var vm = (from c in _sProfessional.ReadList().Where(x => x.Skills.ToLower().Contains(ServiceName.ToLower()))
                      select c).ToList();

            return View(vm);
        }
        //public ActionResult OfficeSewaView(int? id)
        //{



        //    var vm = _sProfessional.ReadList();

        //    return View(vm);
        //}


        public ActionResult ProfessionalDeletion(int id)
        {
            if (id != 0)
            {
                _sProfessional.ProfessionalDeletion(id);
            }
            return RedirectToAction("Professional", "AdminOrderDetail");
        }
        [HttpGet]
        public ActionResult ProfessionalUpdate(int id)
        {
            if (id != 0)
            {
                var data = _sProfessional.List().Where(x => x.Id == id).FirstOrDefault();
                if (data != null)
                {
                    var vm = new ProfessionalUpdateViewModel()
                    {
                        Id = data.Id,
                        Name = data.Name,
                        Email = data.Email,
                        Phone = data.Phone,
                        Address = data.Address,
                        Gender = data.Gender,

                        Remark = data.Remark,
                        Skills = data.Skills,
                    };
                    return View(vm);
                }

            }

            return RedirectToAction("Professional", "AdminOrderDetail");

        }
        [HttpPost]
        public ActionResult ProfessionalUpdate(ProfessionalUpdateViewModel vm)
        {
            if (vm != null)
            {
                var professional = new ProfessionalListViewModel()
                {
                    Skills = vm.Skills,
                    Remark = vm.Remark,

                    Gender = vm.Gender,
                    Address = vm.Address,
                    Email = vm.Email,
                    Id = vm.Id,
                    Name = vm.Name,

                    Phone = vm.Phone,

                };
                _sProfessional.ProfesssionalUpdate(professional);
            }

            return RedirectToAction("Professional", "AdminOrderDetail");
        }




    }
}







 