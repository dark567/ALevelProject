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
        public DbSet<DicClient> DicClient { get; set; }
        public DbSet<DicGood> DicGood { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<JorOrder> JorOrder { get; set; }

        public EFDBContext() : base("DefaultConnection") { }
    }
}
