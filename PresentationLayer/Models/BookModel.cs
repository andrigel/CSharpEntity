using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PresentationLayer.Models
{
    public class BookViewModel
    {
        public Book Book;
        public AuthorViewModel Author { get; set; }
    }
}
