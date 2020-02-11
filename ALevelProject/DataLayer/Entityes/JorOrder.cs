using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Display(Name = "Дата Заказа")]
        public DateTime DateAdd { get; set; } = DateTime.Now;

        [StringLength(10, MinimumLength = 4, ErrorMessage = "The name cannot be longer than 10 characters and less than 4.")]
        [Display(Name = "Номер")]
        [Required]
        public string Num { get; set; }

        public Guid? ClientId { get; set; }
        public DicClient Client { get; set; }

        public Guid? GoodId { get; set; }
        public DicGood Good { get; set; }

        [DefaultValue(0)]
        public int Value { get; set; }
        [Display(Name = "Описание")]
        [DefaultValue("")]
        public string Description { get; set; }
        [Display(Name = "Сотрудник")]
        [DefaultValue("n/a")]
        public string EmployeeName { get; set; }
        [Display(Name = "Оплата")]
        [DefaultValue(true)]
        public bool Pay { get; set; }

    }
}
