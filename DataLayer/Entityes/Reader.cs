using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.Entityes
{
    public class Reader
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