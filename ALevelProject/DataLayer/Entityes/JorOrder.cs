using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entityes
{
    [Table("JorOrders")]
    public class JorOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OrderId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "DateAdd")]
        public DateTime DateAdd { get; set; }
        [StringLength(10, MinimumLength = 4, ErrorMessage = "The name cannot be longer than 10 characters and less than 4.")]
        [Display(Name = "Num")]
        public string Num { get; set; }
        public DicClient ClientId { get; set; }
        public DicGood GoodId { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
    }
}
