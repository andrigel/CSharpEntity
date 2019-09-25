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
            var _book = _dataManager.Books.GetBookById(bookId, true);
            AuthorViewModel _aurhor = _aurhorServise.
            return new BookViewModel() { Book = _book, Author =  };
        }
        public DirectoryEditModel GetDirectoryEdetModel(int directoryid = 0)
        {
            if (directoryid != 0)
            {
                var _dirDB = _dataManager.Directorys.GetDirectoryById(directoryid);
                var _dirEditModel = new DirectoryEditModel()
                {
                    Id = _dirDB.Id,
                    Title = _dirDB.Title,
                    Html = _dirDB.Html
                };
                return _dirEditModel;
            }
            else { return new DirectoryEditModel() { }; }
        }
        public DirectoryViewModel SaveDirectoryEditModelToDb(DirectoryEditModel directoryEditModel)
        {
            Directory _directoryDbModel;
            if (directoryEditModel.Id != 0)
            {
                _directoryDbModel = _dataManager.Directorys.GetDirectoryById(directoryEditModel.Id);
            }
            else
            {
                _directoryDbModel = new Directory();
            }
            _directoryDbModel.Title = directoryEditModel.Title;
            _directoryDbModel.Html = directoryEditModel.Html;

            _dataManager.Directorys.SaveDirectory(_directoryDbModel);

            return DirectoryDBToViewModelById(_directoryDbModel.Id);
        }

        public DirectoryEditModel CreateNewDirectoryEditModel()
        {
            return new DirectoryEditModel() { };
        }
    }
}
