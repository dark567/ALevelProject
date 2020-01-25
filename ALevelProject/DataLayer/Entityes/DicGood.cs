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
    public class DicGood
    {
        [Key]
        public int GoodId { get; set; }
        public string Name { get; set; }
        public int MaxValue { get; set; }
        public int MinValue { get; set; }
        public string Description { get; set; }
    }
}
