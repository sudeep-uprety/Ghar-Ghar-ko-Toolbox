using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GharToolBax.DB
{
    public class EService
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string ImageUrl { get; set; }
        public ServiceCategory Category { get; set; }
        public bool IsActive { get; set; }
    }

    public enum ServiceCategory
    {
        
        HomeMaintainanceSewa,
        OfficeMaintainanceSewa,
        
    }
}