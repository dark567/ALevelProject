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
    public class DicClient
    {
        [Key]
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Secname { get; set; }
        public int Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public byte[] Photo { get; set; }
    }
}
