using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GharToolBax.ViewModels
{
    public class OrderPlaceViewModel
    {

        public int ProfessionalId { get; set; }
        public int UserId{ get; set; }
        public int ServiceId { get; set; }
        public string Problem { get; set; }
        public string FeedBack { get; set; }
        public DateTime OrderDate { get; set; }
    }
}