using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GharToolBax.ViewModels
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ServiceId { get; set; }
        public string ProfessionalName { get; set; }
        public string UserName { get; set; }
        public string ServiceName { get; set; }
        public string Problem { get; set; }
        public string UserAddress { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime OrderDate { get; set; }
    }
}