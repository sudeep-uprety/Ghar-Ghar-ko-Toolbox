using GharToolBax.DB;
using GharToolBax.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GharToolBax.Services
{
    public class SService
    {
        GharToolDB db = null;
        public SService()
        {
            db = new GharToolDB();
        }
        public ServiceViewModel CreateService(ServiceViewModel vm)
        {
            DB.EService data = new EService()
            {
                ServiceName = vm.ServiceName,
                ImageUrl = vm.ImageUrl,
                IsActive = vm.IsActive,
                Category = vm.Category
            };
            db.Service.Add(data);
            db.SaveChanges();
            return vm;
        }

        public List<ServicesListViewModel> ReadList()
        {
            var data = db.Service.ToList();
            var result = (from c in data
                          select new ServicesListViewModel()
                          {
                              Id = c.Id,
                              ServiceName = c.ServiceName,
                              ImageUrl = c.ImageUrl,
                              Category = c.Category,
                              IsActive = c.IsActive,
                          }).ToList();
            return result;
        }

        public List<EService> List()
        {
            return db.Service.ToList();
        }
        public ServiceUpdateViewModel GetUpdateService(int Id)
        {

            var result = (from c in db.Service.Where(x => x.Id == Id)
                          select new ServiceUpdateViewModel()
                          {
                              Id = c.Id,
                              ServiceName = c.ServiceName,
                              ImageUrl = c.ImageUrl,
                              IsActive = c.IsActive,
                              Category = c.Category,
                          }).FirstOrDefault();

            return result;
        }
        public ServiceUpdateViewModel UpdateService(ServiceUpdateViewModel vm)
        {
            var data = db.Service.Where(x => x.Id == vm.Id).FirstOrDefault();
            if (data != null)
            {
                data.ServiceName = vm.ServiceName;
                data.ImageUrl = vm.ImageUrl;
                data.IsActive = vm.IsActive;
                data.Category = vm.Category;
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            };
            return vm;
        }

        public int DeleteService(int serviceId)
        {
            var data = db.Service.Where(x => x.Id == serviceId).FirstOrDefault();
            if (data != null)
            {
                db.Service.Remove(data);
                db.SaveChanges();
            }
            return 1;
        }




    }
}