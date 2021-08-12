using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GharToolBax.DB
{
    public class GharToolDB : DbContext
    {
        public GharToolDB() : base("name=GharToolDB")
        {

        }

        public DbSet<EUserInfo> UserInfo { get; set; }


        public DbSet<EService> Service { get; set; }
        public DbSet<ELogin> Login { get; set; }

        //public DbSet<EOrderDetail>  OrderDetail { get; set; }
        public DbSet<EOrderPlace> OrderPlace { get; set; }
        public DbSet<ECustomerReview> CustomerReview { get; set; }


        public System.Data.Entity.DbSet<GharToolBax.ViewModels.ProfessionalViewModel> ProfessionalViewModels { get; set; }
    }
}