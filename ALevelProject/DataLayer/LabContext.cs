﻿using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class LabContext : DbContext
    {
        public DbSet<DicClient> DicClients { get; set; }
        public DbSet<DicGood> DicGoods { get; set; }

        static LabContext()
        {
            Database.SetInitializer<LabContext>(new StoreDbInitializer());
        }
        public LabContext(string connectionString)
            : base(connectionString)
        {
        }
        public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<LabContext>
        {
            protected override void Seed(LabContext db)
            {
                //db.Phones.Add(new Phone { Name = "Nokia Lumia 630", Company = "Nokia", Price = 220 });
                //db.Phones.Add(new Phone { Name = "iPhone 6", Company = "Apple", Price = 320 });
                //db.Phones.Add(new Phone { Name = "LG G4", Company = "lG", Price = 260 });
                //db.Phones.Add(new Phone { Name = "Samsung Galaxy S 6", Company = "Samsung", Price = 300 });
                db.SaveChanges();
            }
        }
    }
}
