using GharToolBax.DB;
using GharToolBax.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GharToolBax.Common
{


    public class UserSession
    {


        public static EUserInfo UserInfoViewModel
        {
            get
            {
                return GetSession("UserInfoViewModel") as EUserInfo;
            }
            set
            {
                SetSession("UserInfoViewModel", value);
            }
        }
        public static int LoggedUserId
        {
            get
            {
                return (int)(GetSession("LoggedUserId") ?? 0);
            }
            set
            {
                SetSession("LoggedUserId", value);
            }
        }
        public static int ServiceId
        {
            get
            {
                return (int)(GetSession("ServiceId") ?? 0);
            }
            set
            {
                SetSession("ServiceId", value);
            }
        }



        private static object GetSession(string key)
        {
            return HttpContext.Current.Session[key];
        }
        private static void SetSession(string key, object value)
        {
            HttpContext.Current.Session[key] = value;
        }

    }
}