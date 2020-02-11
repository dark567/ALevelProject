using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabTestVerThree.Models
{
    public class EventsDetails
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string EventMessage { get; set; }    // сообщение об событие
        public string ControllerName { get; set; }  // контроллер, где возникло событие
        public string ActionName { get; set; }  // действие, где возникло событие
        public string StackTrace { get; set; }  // стек событие
    }
}