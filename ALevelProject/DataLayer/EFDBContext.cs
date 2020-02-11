using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class EFDBContext : DbContext
    {
        public DbSet<DicClient> DicClients { get; set; }
        public DbSet<DicGood> DicGoods { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<JorOrder> JorOrders { get; set; }
        //public DbSet<JorAddResult> JorAddResults { get; set; }
        //public DbSet<JorResult> JorResults { get; set; }

        public EFDBContext() : base("DefaultConnection") {
            Configuration.LazyLoadingEnabled = false;
        }
    }
}
