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
    public class EFBookRepository : IBookRepository
    {
        private EFDBContext context;
        public EFBookRepository(EFDBContext context)
        {
            this.context = context;
        }
        public void DeleteBook(Book book)
        {
            if (book != null)
             {
                /*context.Entry(book).State = EntityState.Deleted;
                 context.SaveChanges();*/
                context.book.Remove(book);
                context.SaveChanges();
             }
          //AdoNetTools.DeleteBook(Id);
        }
        public IEnumerable<Book> GetAllBooks(bool IncludeAuthors=false)
        {
            if (IncludeAuthors)
                return context.Set<Book>().Include(x => x.Author).AsNoTracking().ToList();
            else
            return context.book.ToList();
        }

        public Book GetBookById(int id)
        {
                return context.Set<Book>().Include(x => x.Author).FirstOrDefault(x => x.Id == id);
        }

        public void SaveBook(Book book)
        {
            if (book.Id == 0)
                context.book.Add(book);
            else
                context.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
