using BuissnesLayer.Interfaces;
using DataLayer;
using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                Book _book = new Book() { Id = book.Id };
                    context.book.Attach(_book);
                    context.Entry(_book).State = EntityState.Deleted;
                    context.ChangeTracker.DetectChanges();
                    context.SaveChanges();
            }
        }

        public IEnumerable<Book> GetAllBooks()
        {
                return context.book.ToList();
        }

        public Book GetBookById(int id)
        {
                return context.book.FirstOrDefault(x => x.Id == id);
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
