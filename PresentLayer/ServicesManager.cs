using BuissnesLayer;
using PresentationLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer
{
    public class ServicesManager
    {
        private DataManager _dataManager;
        private BookService _bookService;
        private ReaderService _readerService;
        private AuthorService _authorService;
        private LogService _logService;

        public ServicesManager(DataManager dataManager)
        {
            _dataManager = dataManager;
            _bookService = new BookService(dataManager);
            _readerService = new ReaderService(dataManager);
            _authorService = new AuthorService(dataManager);
            _logService = new LogService(dataManager);
        }
        public BookService Books { get { return _bookService; } }
        public ReaderService Readers { get { return _readerService; } }
        public AuthorService Authors { get { return _authorService; } }
        public LogService Logs { get { return _logService; } }

    }
}