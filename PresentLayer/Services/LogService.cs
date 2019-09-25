using BuissnesLayer;
using DataLayer.Entityes;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Services
{
    public class LogService
    {
        private DataManager _dataManager;
        private ReaderService _readerService;
        private BookService _bookService;
        public LogService(DataManager dataManager)
        {
            this._dataManager = dataManager;
        }

        public List<LogViewModel> GetLogsList()
        {
            var _logs = _dataManager.Logs.GetAllLogs();
            List<LogViewModel> _modelsList = new List<LogViewModel>();
            foreach (var item in _logs)
            {
                _modelsList.Add(LogDBModelToViewById(item.Id));
            }
            return _modelsList;
        }

        public LogViewModel LogDBModelToViewById(int logId)
        {
            var _log = _dataManager.Logs.GetLogById(logId, true);

            ReaderViewModel _reader = _readerService.ReaderDBModelToViewById(_log.Reader.Id);
            BookViewModel _book = _bookService.BookDBToViewModelById(_log.Book.Id);
            return new LogViewModel() { Log = _log, Reader = _reader, Book = _book };
        }
        public LogEditModel GetLogEditModel(int logId = 0)
        {
            if (logId != 0)
            {
                var _logDB = _dataManager.Logs.GetLogById(logId, true);
                var _logEditModel = new LogEditModel()
                {
                    Id = _logDB.Id,
                    ReaderId = _logDB.Reader.Id,
                    BookId = _logDB.Book.Id,
                    DateOfIssue = _logDB.DateOfIssue,
                    DateOfReturn = _logDB.DateOfReturn, 
                };
                return _logEditModel;
            }
            else { return new LogEditModel() { }; }
        }
        public LogViewModel SaveLogEditModelToDb(LogEditModel logEditModel)
        {
            Log _logDbModel;
            if (logEditModel.Id != 0)
            {
                _logDbModel = _dataManager.Logs.GetLogById(logEditModel.Id);
            }
            else
            {
                _logDbModel = new Log();
            }
            _logDbModel.Id = logEditModel.Id;
            _logDbModel.Book = _dataManager.Books.GetBookById(logEditModel.BookId);
            _logDbModel.Reader = _dataManager.Readers.GetReaderById(logEditModel.ReaderId);
            _logDbModel.DateOfIssue = logEditModel.DateOfIssue;
            _logDbModel.DateOfReturn = logEditModel.DateOfReturn;

            _dataManager.Logs.SaveLog(_logDbModel);

            return LogDBModelToViewById(_logDbModel.Id);
        }

        public LogEditModel CreateNewLogEditModel()
        {
            return new LogEditModel();
        }
    }
}
