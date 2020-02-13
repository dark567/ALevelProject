using DataLayer.Entityes;
using System;

namespace DataLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<DicClient> DicClients { get; }
        IRepository<DicGood> DicGoods { get; }
        //IRepository<Gender> Genders { get; }
        //IRepository<JorOrder> JorOrders { get; }
        //IRepository<JorAddResult> JorAddResults { get; }
        //IRepository<JorResult> JorResults { get; }
        void Save();
    }
}
