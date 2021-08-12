using GharToolBax.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GharToolBax.Services
{
    public class SOrderPlace
    {
        DB.GharToolDB dbContext = null;

        public SOrderPlace()
        {
            dbContext = new DB.GharToolDB();
        }

        public DB.EOrderPlace OrderPlaceDetail(OrderPlaceViewModel vm)
        {
            DB.EOrderPlace orderplace = new DB.EOrderPlace()
            {
                ProfessionalId = vm.ProfessionalId,
                UserId = vm.UserId,
                ServicId = vm.ServiceId,
                Problem = vm.Problem,
                OrderDate = vm.OrderDate,
            };
            dbContext.OrderPlace.Add(orderplace);
            dbContext.SaveChanges();
            return orderplace;
        }

        public List<DB.EOrderPlace> GetEOrderPlaces() {
            var result = (from c in dbContext.OrderPlace
                          select c).ToList();
            return result;

        }
        public bool OrderDelivered(int Id)
        {

            var result = dbContext.OrderPlace.Where(x => x.Id == Id).FirstOrDefault();
            result.IsCompleted = true;
            dbContext.Entry(result).State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
            return true;

        }

        public List<OrderDetailViewModel> GetOrderDetails()  {

            var result = (from c in dbContext.OrderPlace
                          join user in dbContext.UserInfo on c.UserId equals user.Id
                          join prof in dbContext.UserInfo on c.ProfessionalId equals prof.Id
                          join serv in dbContext.Service on c.ServicId equals serv.Id
                          select new OrderDetailViewModel() {
                              Id = c.Id,
                              UserId = c.UserId,
                              OrderDate = c.OrderDate,
                              Problem = c.Problem,
                              ProfessionalName = prof.Name,
                              ServiceName = serv.ServiceName,
                              UserAddress = user.Address,
                              UserName = user.Name,
                              IsCompleted = c.IsCompleted
                          }).ToList();
            return result;



        }

        public DB.ECustomerReview CreateReview(FeedBackViewModel vm)
        {
            DB.ECustomerReview customerreview = new DB.ECustomerReview()
            {
                ProfessionalId = vm.ProfId,
                UserID = vm.UserId, 
                ServicId = vm.ServiceId,
                Feedback = vm.FeedBack,
            };
            dbContext.CustomerReview.Add(customerreview);
            dbContext.SaveChanges();
            return customerreview;
        }



    }       
}

