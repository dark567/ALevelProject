using BuissnesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnesLayer.Interfaces
{
    public interface IGoodService
    {
        //void MakeOrder(DicGoodsDTO orderDto);
        DicClientsDTO GetClient(Guid? id);
        IEnumerable<DicClientsDTO> GetClients();
        void Dispose();
    }
}
