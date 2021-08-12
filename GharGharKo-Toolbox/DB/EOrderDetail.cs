using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GharToolBax.DB
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int UserInfoDetailId { get; set; }
        public int OrderId { get; set; }
        public int ServiceDetailId { get; set; }
        public int professionalId { get; set; }

        public String Remarks { get; set; }






        public virtual EService ServicesDetail { get; set; }

        public virtual EUserInfo UserInfoDetail { get; set; }
    }

}