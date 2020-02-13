using System;
using DataLayer.Interfaces;
using DataLayer.Entityes;

namespace DataLayer.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private LabContext db;
        private DicClientRepository dicClientRepository;
        private DicGoodRepository dicGoodRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new LabContext(connectionString);
        }

        public IRepository<DicClient> DicClients
        {
            get
            {
                if (dicClientRepository == null)
                    dicClientRepository = new DicClientRepository(db);
                return dicClientRepository;
            }
        }

        public IRepository<DicGood> DicGoods
        {
            get
            {
                if (dicGoodRepository == null)
                    dicGoodRepository = new DicGoodRepository(db);
                return dicGoodRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
