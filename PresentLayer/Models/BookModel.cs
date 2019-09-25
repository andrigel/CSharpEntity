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
    public class BookEditModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public int Price { get; set; }
    }
}
