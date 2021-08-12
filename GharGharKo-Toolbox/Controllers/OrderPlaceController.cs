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
    public class OrderPlaceController : Controller
    {

        SOrderPlace _sOrderPlace = null;
        public OrderPlaceController()
        {
            _sOrderPlace = new SOrderPlace();

        }



        // GET: OrderPlace
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PlaceOrder(int ProfessionalId , string ProblemState)  {

            if (Common.UserSession.UserInfoViewModel == null)
            {

                return RedirectToAction("Index", "Login");
            }

            int UserId = Common.UserSession.LoggedUserId;
            int ServiceId = Common.UserSession.ServiceId;
            OrderPlaceViewModel vm = new OrderPlaceViewModel()
            {
                OrderDate = DateTime.Now,
                Problem = ProblemState,
                ProfessionalId = ProfessionalId,
                ServiceId = ServiceId,
                UserId = UserId
            };
            var result = _sOrderPlace.OrderPlaceDetail(vm);
            return View();
        }
        public ActionResult OrderCreate(OrderPlaceViewModel vm)
        {
            if (ModelState.IsValid)
             {
                var result = _sOrderPlace.OrderPlaceDetail(vm);

                EOrderPlace OrderPlace = new EOrderPlace()
                {
                    ProfessionalId = vm.ProfessionalId,
                    UserId = vm.UserId,
                    Problem = vm.Problem,
                    OrderDate = vm.OrderDate
                };



            };
            _sOrderPlace.OrderPlaceDetail(vm);
            return View(vm);

        }

        //public ActionResult CreateReview(OrderPlaceViewModel vm)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = _sOrderPlace.OrderPlaceDetail(vm);

        //        EOrderPlace Order = new EOrderPlace()
        //        {

        //        };



        //    };
        //    _sOrderPlace.OrderPlaceDetail(vm);
        //    return View(vm);

        //}




    }
}