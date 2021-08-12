using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GharToolBax.DB
{
    public class EOrderPlace
    {
        public int Id { get; set; }
        public int ProfessionalId { get; set; }
        public int UserId { get; set; }
        public int ServicId { get; set; }
        public string Problem { get; set; }
        public bool IsCompleted { get; set; }

      

        public DateTime OrderDate { get; set; }

    }

   



}

