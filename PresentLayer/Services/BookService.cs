using BuissnesLayer;
using DataLayer.Entityes;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Services
{
    public class BookService
    {
        private DataManager _dataManager;
        private AuthorService _authorService;
        public BookService(DataManager dataManager)
        {
            this._dataManager = dataManager;
            this._authorService = new AuthorService(dataManager);
        }

        public List<BookViewModel> GetBooksList()
        {
            var _books = _dataManager.Books.GetAllBooks();
            List<BookViewModel> _modelsList = new List<BookViewModel>();
            foreach (var item in _books)
            {
                _modelsList.Add(BookDBToViewModelById(item.Id));
            }
            return _modelsList;
        }

        public BookViewModel BookDBToViewModelById(int bookId)
        {
            var _book = _dataManager.Books.GetBookById(bookId);
            AuthorViewModel _author = _authorService.AuthorDBModelToViewById(_book.AuthorId);
            return new BookViewModel() { Book = _book, Author = _author };
        }
        public BookEditModel GetBookEditModel(int bookId = 0)
        {
            if (bookId != 0)
            {
                var _bookDB = _dataManager.Books.GetBookById(bookId);
                var _bookEditModel = new BookEditModel()
                {
                    Id = _bookDB.Id,
                    Name = _bookDB.Name,
                    AuthorId = _bookDB.AuthorId,
                    Price = _bookDB.Price
                };
                return _bookEditModel;
            }
            else { return new BookEditModel() { }; }
        }
        public BookViewModel SaveBookEditModelToDb(BookEditModel bookEditModel)
        {
            Book _bookDbModel;
            if (bookEditModel.Id != 0)
            {
                _bookDbModel = _dataManager.Books.GetBookById(bookEditModel.Id);
            }
            else
            {
                _bookDbModel = new Book();
            }
            _bookDbModel.Name = bookEditModel.Name;
            _bookDbModel.AuthorId = bookEditModel.AuthorId;
            _bookDbModel.Price = bookEditModel.Price;

            _dataManager.Books.SaveBook(_bookDbModel);

            return BookDBToViewModelById(_bookDbModel.Id);
        }

        public BookEditModel CreateNewBookEditModel()
        {
            return new BookEditModel() { };
        }
    }
}
