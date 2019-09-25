using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Models
{
    public class LogViewModel
    {
        public Log Log { get; set; }
        public ReaderViewModel Reader { get; set; }
        public BookViewModel Book { get; set; }
    }
    public class LogEditModel
    {
        public int Id { get; set; }
        public int ReaderId { get; set; }
        public int BookId { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfReturn { get; set; }
    }
}
