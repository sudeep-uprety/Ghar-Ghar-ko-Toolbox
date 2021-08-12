using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GharToolBax.DB
{
    public class ECustomerReview
    {
        public int Id { get; set; }
        public int ProfessionalId { get; set; }
        public int UserID { get; set; }
        public int ServicId { get; set; }

        public string Feedback { get; set; }



    }
}