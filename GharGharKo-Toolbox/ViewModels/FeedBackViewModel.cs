using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GharToolBax.ViewModels
{
    public class FeedBackViewModel
    {
        public int UserId { get; set; }
        public int ServiceId { get; set; }
        public int ProfId { get; set; }
        public string FeedBack { get; set; }

    }
}