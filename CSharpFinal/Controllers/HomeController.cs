using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CSharpFinal.Models;
using DataLayer;
using DataLayer.Entityes;
using BuissnesLayer;
using BuissnesLayer.Interfaces;
using PresentationLayer;
using PresentationLayer.Models;

namespace CSharpFinal.Controllers
{
    public class HomeController : Controller
    {
        private DataManager _dataManager;
        private ServicesManager _servicesManager;
        public HomeController(DataManager _dataManager)
        {
            this._dataManager = _dataManager;
            this._servicesManager = new ServicesManager(_dataManager);
        }
        public IActionResult Index()
        {
            return View();
        }
        #region BooksTools
        public IActionResult Books()
        {
            List<Book> _books = _dataManager.Books.GetAllBooks(true).ToList();
            return View(_books);
        }
        public IActionResult BookEdit(int Id)
        {
            BookEditModel _editModel = _servicesManager.Books.GetBookEditModel(Id);
            return View(_editModel);
        }
        public IActionResult BookEdit2(BookEditModel _book)
        {
            _servicesManager.Books.SaveBookEditModelToDb(_book);
            return View("BookEdit",_book);
        }
        public IActionResult BookDelete(int id)
        {
            var book = _dataManager.Books.GetBookById(id);
            _dataManager.Books.DeleteBook(book);
            return View("Books", _dataManager.Books.GetAllBooks(true).ToList());
        }
        public IActionResult BookCreate()
        {
            BookEditModel _editModel = _servicesManager.Books.CreateNewBookEditModel();
            return View(_editModel);
        }
        public IActionResult BookCreate2(BookEditModel _editModel)
        {
            _servicesManager.Books.SaveBookEditModelToDb(_editModel);
            return View("BookCreate", _servicesManager.Books.CreateNewBookEditModel());
        }
        #endregion
        #region ReadersTools
        public IActionResult Readers()
        {
            List<Reader> _readers = _dataManager.Readers.GetAllReaders().ToList();
            return View(_readers);
        }
        public IActionResult ReaderEdit(int Id)
        {
            ReaderEditModel _editModel = _servicesManager.Readers.GetReaderEditModel(Id);
            return View("ReaderEdit",_editModel);
        }
        public IActionResult ReaderEdit2(ReaderEditModel _reader)
        {
            _servicesManager.Readers.SaveReaderEditModelToDb(_reader);
            return View("ReaderEdit", _reader);
        }
        public IActionResult ReaderDelete(int id)
        {
            var reader = _dataManager.Readers.GetReaderById(id);
            _dataManager.Readers.DeleteReader(reader);
            return View("Readers", _dataManager.Readers.GetAllReaders().ToList());
        }
        public IActionResult ReaderCreate()
        {
            ReaderEditModel _editModel = _servicesManager.Readers.CreateNewReaderEditModel();
            return View("ReaderCreate",_editModel);
        }
        public IActionResult ReaderCreate2(ReaderEditModel _editModel)
        {
            _servicesManager.Readers.SaveReaderEditModelToDb(_editModel);
            return View("ReaderCreate", _servicesManager.Readers.CreateNewReaderEditModel());
        }
        #endregion
        #region AuthorsTools
        public IActionResult Authors()
        {
            List<Author> _authors = _dataManager.Authors.GetAllAuthors().ToList();
            return View(_authors);
        }
        public IActionResult AuthorEdit(int Id)
        {
            AuthorEditModel _editModel = _servicesManager.Authors.GetAuthorEditModel(Id);
            return View(_editModel);
        }
        public IActionResult AuthorEdit2(AuthorEditModel _author)
        {
            _servicesManager.Authors.SaveAuthorEditModelToDb(_author);
            return View("AuthorEdit", _author);
        }

        //[Route("")]
        public IActionResult AuthorDelete(int id)
        {
            var author = _dataManager.Authors.GetAuthorById(id);
            _dataManager.Authors.DeleteAuthor(author);
            return View("Authors", _dataManager.Authors.GetAllAuthors().ToList());
        }
        public IActionResult AuthorCreate()
        {
            AuthorEditModel _editModel = _servicesManager.Authors.CreateNewAuthorEditModel();
            return View(_editModel);
        }
        public IActionResult AuthorCreate2(AuthorEditModel _editModel)
        {
            _servicesManager.Authors.SaveAuthorEditModelToDb(_editModel);
            return View("AuthorCreate", _editModel);
        }
        #endregion
        #region LogsTools
        public IActionResult Logs()
        {
            List<Log> _logs = _dataManager.Logs.GetAllLogs(true).ToList();
            return View(_logs);
        }
        public IActionResult LogEdit(int Id)
        {
            LogEditModel _editModel = _servicesManager.Logs.GetLogEditModel(Id);
            return View(_editModel);
        }
        public IActionResult LogEdit2(LogEditModel _log)
        {
            _servicesManager.Logs.SaveLogEditModelToDb(_log);
            return View("LogEdit", _log);
        }
        public IActionResult LogDelete(int id)
        {
            var log = _dataManager.Logs.GetLogById(id,true);
            _dataManager.Logs.DeleteLog(log);
            return View("Logs", _dataManager.Logs.GetAllLogs(true).ToList());
        }
        public IActionResult LogCreate()
        {
            LogEditModel _editModel = _servicesManager.Logs.CreateNewLogEditModel();
            return View(_editModel);
        }
        public IActionResult LogCreate2(LogEditModel _editModel)
        {
            _servicesManager.Logs.SaveLogEditModelToDb(_editModel);
            return View("LogCreate", _servicesManager.Logs.CreateNewLogEditModel());
        }
        #endregion
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
