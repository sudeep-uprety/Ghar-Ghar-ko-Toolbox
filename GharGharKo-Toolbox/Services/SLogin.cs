using GharToolBax.DB;
using GharToolBax.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GharToolBax.Services
{
    public class SLogin
    {
        DB.GharToolDB dbContext = null;

        public SLogin()
        {
            dbContext = new DB.GharToolDB();

        }

        public ELogin CreateLogin(ELogin login)
        {
            dbContext.Login.Add(login);
            dbContext.SaveChanges();
            return login;
        }

        public List<ELogin> List()
        {
            return dbContext.Login.ToList();
        }


        public List<EUserInfo> UserInfoList()
        {
            return dbContext.UserInfo.ToList();
        }
    }
}