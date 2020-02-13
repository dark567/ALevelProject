using DataLayer.Entityes;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataLayer.Repositories
{
    public class DicClientRepository: IRepository<DicClient>
    {
        private LabContext db;

        public DicClientRepository(LabContext context)
        {
            this.db = context;
        }

        public IEnumerable<DicClient> GetAll()
        {
            return db.DicClients;
        }

        public DicClient Get(Guid id)
        {
            return db.DicClients.Find(id);
        }

        public void Create(DicClient client)
        {
            db.DicClients.Add(client);
        }

        public void Update(DicClient client)
        {
            db.Entry(client).State = EntityState.Modified;
        }

        public IEnumerable<DicClient> Find(Func<DicClient, Boolean> predicate)
        {
            return db.DicClients.Where(predicate).ToList();
        }

        public void Delete(Guid id)
        {
            DicClient client = db.DicClients.Find(id);
            if (client != null)
                db.DicClients.Remove(client);
        }
    }
}
