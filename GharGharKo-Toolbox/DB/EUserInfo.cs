
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GharToolBax.DB
{
    public class EUserInfo
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Skills { get; set; }
        public string Address { get; set; }


        public string Phone { get; set; }  
        public string Gender { get; set; }
        public string Remark { get; set; }

        public string ImageUrl { get; set; }
        public Role Role { get; set; }
        public DateTime CreatedDate { get; set; }

    }

    public enum Role
    {
        Admin,
        Professional,
        User
    }
}