using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GharToolBax.ViewModels
{
    public class ProfessionalListViewModel
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        

        public string Skills { get; set; }
        public string Remark{ get; set; }

        public string CustomerFeedback { get; set; }

    }
}