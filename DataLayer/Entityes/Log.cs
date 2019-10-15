using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataLayer.Entityes
{
    public class Log
    {
        public int Id { get; set; }
        public Reader Reader { get; set; }
        public Book Book { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfReturn { get; set; }

    }
}