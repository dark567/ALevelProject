using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabTestVerThree.Models
{
    public class ClientViewModel
    {
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }
}