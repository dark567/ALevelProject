using DataLayer.Entityes;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace DataLayer.Repositories
{
    public class DicGoodRepository : IRepository<DicGood>
    {
        private LabContext db;

        public DicGoodRepository(LabContext context)
        {
            this.db = context;
        }

        public IEnumerable<DicGood> GetAll()
        {
            return db.DicGoods;
        }

        public DicGood Get(Guid id)
        {
            return db.DicGoods.Find(id);
        }

        public void Create(DicGood good)
        {
            db.DicGoods.Add(good);
        }

        public void Update(DicGood good)
        {
            db.Entry(good).State = EntityState.Modified;
        }

        public IEnumerable<DicGood> Find(Func<DicGood, Boolean> predicate)
        {
            return db.DicGoods.Where(predicate).ToList();
        }

        public void Delete(Guid id)
        {
            DicGood good = db.DicGoods.Find(id);
            if (good != null)
                db.DicGoods.Remove(good);
        }
    }
}
