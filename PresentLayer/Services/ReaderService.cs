using BuissnesLayer;
using DataLayer.Entityes;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Services
{
    public class ReaderService
    {
        private DataManager _dataManager;
        public ReaderService(DataManager dataManager)
        {
            this._dataManager = dataManager;
        }

        public List<ReaderViewModel> GetReadersList()
        {
            var _readers = _dataManager.Readers.GetAllReaders();
            List<ReaderViewModel> _modelsList = new List<ReaderViewModel>();
            foreach (var item in _readers)
            {
                _modelsList.Add(ReaderDBModelToViewModelById(item.Id));
            }
            return _modelsList;
        }

        public ReaderViewModel ReaderDBModelToViewModelById(int readerId)
        {
            var _reader = _dataManager.Readers.GetReaderById(readerId);
            return new ReaderViewModel() { Reader = _reader };
        }
        public ReaderEditModel GetReaderEditModel(int readerId = 0)
        {
            if (readerId != 0)
            {
                var _readerDB = _dataManager.Readers.GetReaderById(readerId);
                var _readerEditModel = new ReaderEditModel()
                {
                    Id = _readerDB.Id,
                    Name = _readerDB.Name,
                    Surname = _readerDB.Surname,
                    Patronymic = _readerDB.Patronymic,
                    Region = _readerDB.Region,
                    District = _readerDB.District,
                    TicketNumber = _readerDB.TicketNumber,
                    Telephone = _readerDB.Telephone
                };
                return _readerEditModel;
            }
            else { return new ReaderEditModel() { }; }
        }
        public ReaderViewModel SaveReaderEditModelToDb(ReaderEditModel readerEditModel)
        {
            Reader _readerDbModel;
            if (readerEditModel.Id != 0)
            {
                _readerDbModel = _dataManager.Readers.GetReaderById(readerEditModel.Id);
            }
            else
            {
                _readerDbModel = new Reader();
            }
            _readerDbModel.Id = readerEditModel.Id;
            _readerDbModel.Name = readerEditModel.Name;
            _readerDbModel.Surname = readerEditModel.Surname;
            _readerDbModel.District = readerEditModel.District;
            _readerDbModel.TicketNumber = readerEditModel.TicketNumber;
            _readerDbModel.Telephone = readerEditModel.Telephone;

            _dataManager.Readers.SaveReader(_readerDbModel);

            return ReaderDBModelToViewModelById(_readerDbModel.Id);
        }

        public ReaderEditModel CreateNewReaderEditModel()
        {
            return new ReaderEditModel() { };
        }
    }
}
