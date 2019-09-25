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
        public AuthorViewModel AuthorDBModelToView(int id)
        {
            var _model = new AuthorViewModel() { Author = dataManager.Authors.GetAuthorById(id) };
            return _model;
        }
    }
}
