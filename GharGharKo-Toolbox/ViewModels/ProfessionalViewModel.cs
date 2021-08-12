using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GharToolBax.ViewModels
{
    public class ProfessionalViewModel
    {

        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public  string Remark { get; set; }

        public string Skills { get; set; }

    }
}