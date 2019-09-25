using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Models
{
    public class AuthorViewModel
    {
        public Author Author;
    }
    public class AuthorEditModel
    { 
        public int Id;
        public string name;
        public string surname;
    }
}
