using BuissnesLayer.Interfaces;
using DataLayer;
using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdoNet;

namespace BuissnesLayer.Implementations
{
    public class EFAuthorRepository : IAuthorRepository
    {
        private EFDBContext context;
        public EFAuthorRepository(EFDBContext context)
        {
            this.context = context;
        }

        public void DeleteAuthor(Author author)
        {
            if (author != null)
            {
                /*context.Entry(book).State = EntityState.Deleted;
                 context.SaveChanges();*/
                context.author.Remove(author);
                context.SaveChanges();
            }
            //AdoNetTools.DeleteAuthor(id);
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return context.author.ToList();
        }

        public Author GetAuthorById(int id)
        {
            return context.author.Include(a => a.Books).FirstOrDefault(x => x.Id == id);
        }

        public void SaveAuthor(Author author)
        {
            if (author.Id == 0)
                context.author.Add(author);
            else
                context.Entry(author).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
