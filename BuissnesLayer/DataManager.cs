using BuissnesLayer.Interfaces;
using DataLayer;
using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuissnesLayer
{
    public class DataManager
    {
        private IBookRepository BookRep;
        private IAuthorRepository AuthorRep;
        private IReaderRepository ReaderRep;
        private ILogRepository LogRep;

        public DataManager(IBookRepository bookRep, IAuthorRepository authorRep, IReaderRepository readerRep, ILogRepository logRep)
        {
            BookRep = bookRep;
            AuthorRep = authorRep;
            ReaderRep = readerRep;
            LogRep = logRep;
        }

        public IBookRepository Books { get { return BookRep; } }
        public IAuthorRepository Authors { get { return AuthorRep; } }
        public IReaderRepository Readers { get { return ReaderRep; } }
        public ILogRepository Logs { get { return LogRep; } }
    }
}
