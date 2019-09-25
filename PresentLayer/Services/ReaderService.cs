using BuissnesLayer;
using DataLayer.Entityes;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.Services
{
    public class ReaderService
    {
        private DataManager dataManager;
        public ReaderService(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public ReaderViewModel ReaderDBModelToViewById(int readerId)
        {
            var _model = new ReaderViewModel()
            {
                Reader = dataManager.Readers.GetReaderById(readerId),
            };
            return _model;
        }

        public ReaderEditModel GetReaderEditModel(int readerId)
        {
            var _dbModel = dataManager.Readers.GetReaderById(readerId);
            var _editModel = new ReaderEditModel()
            {
                Id = _dbModel.Id,
                Surname = _dbModel.Surname,
                Name = _dbModel.Name,
                Patronymic = _dbModel.Patronymic,
                Region = _dbModel.Region,
                District = _dbModel.District,
                TicketNumber = _dbModel.TicketNumber,
                Telephone = _dbModel.Telephone,
            };
            return _editModel;
        }

        public ReaderViewModel SaveReaderEditModelToDb(ReaderEditModel editModel)
        {
            Reader reader;
            if (editModel.Id != 0)
            {
                reader = dataManager.Readers.GetReaderById(editModel.Id);
            }
            else
            {
                reader = new Reader();
            }
            reader.Id = editModel.Id;
            reader.Surname = editModel.Surname;
            reader.Name = editModel.Name;
            reader.Patronymic = editModel.Patronymic;
            reader.Region = editModel.Region;
            reader.District = editModel.District;
            reader.TicketNumber = editModel.TicketNumber;
            reader.Telephone = editModel.Telephone;
            dataManager.Readers.SaveReader(reader);
            return ReaderDBModelToViewById(reader.Id);
        }
        public ReaderEditModel CreateNewReaderEditModel()
        {
            return new ReaderEditModel() {};
        }

    }
}
