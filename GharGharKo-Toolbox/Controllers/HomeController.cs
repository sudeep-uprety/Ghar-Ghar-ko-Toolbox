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
    public class HomeController : Controller
    {
        SService _service = null;
        SOrderPlace _orderPlace = null;
        SProfessional _sProfessional = null;
        UserServices _userServices = null;

        public HomeController()
        {
            _service = new SService();
            _orderPlace = new SOrderPlace();
            _sProfessional = new SProfessional();

            _userServices = new UserServices();
        }
        public ActionResult Index()
        {
            if (Common.UserSession.UserInfoViewModel == null) {

                return RedirectToAction("Index", "Login");
            }
            var Servicelist = _service.ReadList();
    
            return View(Servicelist);
        

        }

    //    [HttpGet]
    //    public ActionResult EditUserInfo()
    //    {


    //        return View();
    //    }

    //    [HttpPost]
    //    public ActionResult EditUserInfo( eeUserInfo)



    //    UserInfoUpdateViewModel userInfoUpdate = new UserInfoUpdateViewModel();


    //    {


    //    };
    //    var result = _userServices(userInfoUpdateViewModal);
    //        return RedirectToAction("Home");


      
    //        return View();
    //}
    public ActionResult ProfessionalIndex()
        {
            if (Common.UserSession.UserInfoViewModel == null)
            {

                return RedirectToAction("Index", "Login");
            }
            var Professionallist = _sProfessional.ReadList();

            return View(Professionallist);


        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult UserOrder() {

            if (Common.UserSession.UserInfoViewModel == null)
            {

                return RedirectToAction("Index", "Login");
            }
            int UserId = Common.UserSession.LoggedUserId;
            //var result = _orderPlace.GetEOrderPlaces().ToList().Where(x => x.UserId == UserId).ToList();
            //return View(result);
            var result = _orderPlace.GetOrderDetails().Where(x => x.UserId == UserId).ToList();
            return View(result);

        }
        public ActionResult Completed(int Id)
        {
            if (Common.UserSession.UserInfoViewModel == null)
            {

                return RedirectToAction("Index", "Login");
            }

            var data = _orderPlace.OrderDelivered(Id);
            return RedirectToAction("UserOrder");
        }

        public ActionResult GiveFeedback(int id , string FeedBack){

            var orderDetail = _orderPlace.GetEOrderPlaces().Where(x => x.Id == id).FirstOrDefault();
            FeedBackViewModel feedBackViewModel = new FeedBackViewModel()
            {
                FeedBack = FeedBack,
                ProfId = orderDetail.ProfessionalId,
                ServiceId = orderDetail.ServicId,
                UserId = orderDetail.UserId
            };
            var result = _orderPlace.CreateReview(feedBackViewModel);
            return RedirectToAction("UserOrder");
        }
    }
}