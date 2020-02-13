using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnesLayer.DTO
{
    public class DicGoodsDTO
    {
        public Guid GoodId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int MaxValue { get; set; }

        public int MinValue { get; set; }
        public string Description { get; set; }

        //public ICollection<JorOrder> jorOrder { get; set; }
    }
}
