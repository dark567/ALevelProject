using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnesLayer.DTO
{
    public class DicClientsDTO
    {
        public Guid ClientId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Secname { get; set; }


        public string FullName { get { return string.Format($"{Surname} {Name} {Secname}").Trim(); } }

        //public Guid GenderId { get; set; }

        //public Gender Gender { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }

        public int Age { get; set; }

        public DateTime BirthDate { get; set; }
        public byte[] Photo { get; set; } //todo ver2

        //public ICollection<JorOrder> jorOrder { get; set; }

    }
}
