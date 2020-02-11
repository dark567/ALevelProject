using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entityes
{
    [Table("JorResults")]
    public class JorResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ResultId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата Заказа")]
        public DateTime DateAdd { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата Выполнения")]
        public DateTime DateDone { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата Отправки")]
        public DateTime DateSent { get; set; } = DateTime.Now;

        [StringLength(10, MinimumLength = 4, ErrorMessage = "The name cannot be longer than 10 characters and less than 4.")]
        [Display(Name = "Номер")]
        [Required]
        public string Num { get; set; }

        [Display(Name = "Клиент")]
        public Guid? ClientId { get; set; }
        public DicClient Client { get; set; }

        [Display(Name = "Услуга")]
        public Guid? GoodId { get; set; }
        public DicGood Good { get; set; }

        public int Value { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Сотрудник")]
        public string EmployeeName { get; set; }
        [Display(Name = "Отправлено")]
        public bool IsSent{ get; set; }
    }
}
