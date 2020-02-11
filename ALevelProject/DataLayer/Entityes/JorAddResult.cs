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
    [Table("JorAddResults")]
    public class JorAddResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AddResultId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата Заказа")]
        public DateTime DateAdd { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата Выполнения")]
        public DateTime DateDone { get; set; } = DateTime.Now;

        [StringLength(10, MinimumLength = 4, ErrorMessage = "The name cannot be longer than 10 characters and less than 4.")]
        [Display(Name = "Номер")]
        [Required]
        public string Num { get; set; }

        [StringLength(10, MinimumLength = 8, ErrorMessage = "The name cannot be longer than 10 characters and less than 4.")]
        [Display(Name = "Штрих код")]
        [Required]
        public string Barcode { get; set; }

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

        [Display(Name = "Выполнено")]
        [DefaultValue(false)]
        public bool IsFinished { get; set; }
    }
}
