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
        public IActionResult Books()
        {
            List<Book> _books = _dataManager.Books.GetAllBooks().ToList();
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
        public IActionResult BookDelete(Book _book)
        {
            _dataManager.Books.DeleteBook(_book);
            List<Book> _books = _dataManager.Books.GetAllBooks().ToList();
            return View("Books", _dataManager.Books.GetAllBooks().ToList());
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
        public IActionResult Authors()
        {
            List<Author> _authors = _dataManager.Authors.GetAllAuthors().ToList();
            return View(_authors);
        }
        public IActionResult Readers()
        {
            List<Reader> _readers = _dataManager.Readers.GetAllReaders().ToList();
            return View(_readers);
        }
        public IActionResult Logs()
        {
            List<Log> _logs = _dataManager.Logs.GetAllLogs(true).ToList();
            return View(_logs);
        }
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
