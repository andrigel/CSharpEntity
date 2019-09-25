using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entityes;

namespace PresentationLayer.Models
{
    public class ReaderViewModel
    {
        public Reader Reader { get; set; }
    }
    public class ReaderEditModel
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public int TicketNumber { get; set; }
        public string Telephone { get; set; }
    }
}
