using BuissnesLayer;
using DataLayer.Entityes;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.Services
{
    public class AuthorService
    {
        private DataManager dataManager;
        public AuthorService(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public AuthorViewModel AuthorDBModelToViewById(int authorId)
        {
            var _model = new AuthorViewModel
            {
                Author = dataManager.Authors.GetAuthorById(authorId),
            };
            return _model;
        }

        public AuthorEditModel GetAuthorEditModel(int authorId)
        {
            var _dbModel = dataManager.Authors.GetAuthorById(authorId);
            var _editModel = new AuthorEditModel()
            {
                Id = _dbModel.Id,
                name = _dbModel.Name,
                surname = _dbModel.Surname
            };
            return _editModel;
        }

        public AuthorViewModel SaveAuthorEditModelToDb(AuthorEditModel editModel)
        {
            Author author;
            if (editModel.Id != 0)
            {
                author = dataManager.Authors.GetAuthorById(editModel.Id);
            }
            else
            {
                author = new Author();
            }
            author.Id = editModel.Id;
            author.Name = editModel.name;
            author.Surname = editModel.surname;
            dataManager.Authors.SaveAuthor(author);
            return AuthorDBModelToViewById(author.Id);
        }
        public AuthorEditModel CreateNewAuthorEditModel()
        {
            return new AuthorEditModel() {};
        }

    }
}
