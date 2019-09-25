using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Models
{
    public class LogWiewModel
    {
        public Log Log { get; set; }
        public ReaderViewModel Reader { get; set; }
        public BookViewModel Book { get; set; }
    }
}
