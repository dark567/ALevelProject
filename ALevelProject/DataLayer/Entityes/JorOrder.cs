using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entityes
{
    [Table("DicGoods")]
    public class JorOrder
    {
        [Key]
        public int OrderId { get; set; }
        public DicClient ClientId { get; set; }
        public DicGood GoodId { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
    }
}
