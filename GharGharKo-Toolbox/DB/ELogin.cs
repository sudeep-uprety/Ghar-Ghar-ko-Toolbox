using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GharToolBax.DB
{
    public class ELogin
    {
        public int Id { get; set; }
        public int UserInfoId { get; set; }
        
        public string UserName { get; set; }

        public string Password  { get; set; }
        public Role Role { get; set; }

        public  virtual EUserInfo UserInfo { get; set; }
    }
}