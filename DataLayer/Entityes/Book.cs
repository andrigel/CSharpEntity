﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataLayer.Entityes
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
     //   public int AuthorId { get; set; }
        //[Required]
        public Author Author { get; set; }
        public int Price { get; set; }
        public List<Log> Logs { get; set; }
    }
}