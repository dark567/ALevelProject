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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid GoodId { get; set; }
        [Required]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Code cannot be longer than 4 characters.")]
        //[StringLength(4, MinimumLength = 3)]
        public string Code { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "The name cannot be longer than 50 characters and less than 4.")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Range(0, 100)]
        public int MaxValue { get; set; }
        [Range(0, 100)]
        public int MinValue { get; set; }
        public string Description { get; set; }
    }
}
