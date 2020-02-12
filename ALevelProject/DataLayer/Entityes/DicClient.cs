using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entityes
{
    [Table("DicClients")]
    public class DicClient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ClientId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "The name cannot be longer than 50 characters and less than 4.")]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "The name cannot be longer than 50 characters and less than 4.")]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string Secname { get; set; }

        [Display(Name = "ФИО")]
        public string FullName { get { return string.Format($"{Surname} {Name} {Secname}").Trim(); } }

        public Guid GenderId { get; set; }

        public Gender Gender { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }
        [Range(0, 100)]
        public int Age { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата рождения")]
        public DateTime BirthDate { get; set; }
        public byte[] Photo { get; set; } //todo ver2


        public ICollection<JorOrder> jorOrder { get; set; }

   
    }
}
