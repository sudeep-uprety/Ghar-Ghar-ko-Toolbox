using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GharToolBax.DB;
using GharToolBax.ViewModels;

namespace GharToolBax.Services
{
    public class SProfessional
    {
        DB.GharToolDB dbContext = null;
        public SProfessional()
        {
            dbContext = new DB.GharToolDB();
        }

        public EUserInfo CreateProfessional(UserInfoViewModel sp)
        {
            DB.EUserInfo eProfessional = new DB.EUserInfo()
            {

                Name = sp.Name,
                Address = sp.Address,
                Phone = sp.Phone,
                Gender = sp.Gender,
                Remark = sp.Remark,
                Skills = sp.Skills,

                Role = DB.Role.Professional,
                CreatedDate = DateTime.Now,
                Email = sp.Email,
                ImageUrl = sp.ImageUrl,
                //Password = sp.Password,

            };
            dbContext.UserInfo.Add(eProfessional);
            dbContext.SaveChanges();
            return eProfessional;

        }


        public List<ProfessionalListViewModel> ReadList()
        {
            var data = dbContext.UserInfo.Where(X => X.Role == Role.Professional).ToList();
            var result = (from c in data.ToList()
                          select new ProfessionalListViewModel()
                          {
                              Id = c.Id,
                              Name = c.Name,
                              Email = c.Email,
                              Skills = c.Skills,
                              Phone = c.Phone,
                              Address = c.Address,
                              Gender = c.Gender,
                              CustomerFeedback = GetCustomerFeedBack(c.Id)

                              //Remark= c.Remark,

                          }).ToList();
            return result;

        }
        private string GetCustomerFeedBack(int ProfId) {

            var data = dbContext.CustomerReview.Where(x => x.ProfessionalId == ProfId).Select(x => x.Feedback).ToArray();

            string Feedback = string.Join("," , data);
            return Feedback;
            
        }
        public List<EUserInfo> List()
        {
            return dbContext.UserInfo.ToList();
        }


        public ProfessionalListViewModel ProfesssionalUpdate(ProfessionalListViewModel vm)
        {
            var data = dbContext.UserInfo.Where(x => x.Id == vm.Id).FirstOrDefault();
            if (data != null)
            {
                data.Id = vm.Id;
                data.Name = vm.Name;
                data.Email = vm.Email;
   
                data.Skills = vm.Skills;
                data.Phone = vm.Phone;
                data.Address = vm.Address;
                data.Gender = vm.Gender;
             
                //data.Remark = vm.Remark;
                              
            
               dbContext.Entry(data).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            };
            return vm;
        }

        public int ProfessionalDeletion(int professionalId)
        {
            var data = dbContext.UserInfo.Where(x => x.Id == professionalId).FirstOrDefault();
            if (data != null)
            {
                dbContext.UserInfo.Remove(data);
                dbContext.SaveChanges();
            }
            return 1;
        }
    }
}