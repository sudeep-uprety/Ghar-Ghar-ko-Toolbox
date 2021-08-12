using GharToolBax.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GharToolBax.Services
{
    public class UserServices
    {
        DB.GharToolDB dbContext = null;
        public UserServices()
        {
            dbContext = new DB.GharToolDB();
        }

        public DB.EUserInfo CreateUser(UserInfoViewModel vm)
        {

            DB.EUserInfo userInfo = new DB.EUserInfo()
            {
                Id = vm.Id,
                Name = vm.Name,
                Address = vm.Address,
                Phone = vm.Phone,
                Gender = vm.Gender,
                Remark = vm.Remark,

                Email = vm.Email,
                Password = vm.Password,
                ImageUrl = vm.ImageUrl,

                CreatedDate = DateTime.Now,

                Role = DB.Role.User
            };
            dbContext.UserInfo.Add(userInfo);
            dbContext.SaveChanges();
            return userInfo;

        }



        public DB.EUserInfo Create(UserInfoViewModel vm)
        {

            DB.EUserInfo userInfo = new DB.EUserInfo()
            {
                Id = vm.Id,
                Name = vm.Name,
                Address = vm.Address,
                Phone = vm.Phone,
                Gender = vm.Gender,
                Remark = vm.Remark,

                Email = vm.Email,
                Password = vm.Password,
                ImageUrl = vm.ImageUrl,

                CreatedDate = DateTime.Now,

                Role = DB.Role.User
            };
            dbContext.UserInfo.Add(userInfo);
            dbContext.SaveChanges();
            return userInfo;

        }





    }
}