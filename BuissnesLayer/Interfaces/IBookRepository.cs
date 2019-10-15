using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks(bool IncludeAuthors = false);
        Book GetBookById(int id);
        void SaveBook(Book archive);
        void DeleteBook(Book book);

    }
}
