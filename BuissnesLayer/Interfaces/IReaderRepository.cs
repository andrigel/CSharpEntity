using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Interfaces
{
    public interface IReaderRepository
    {
        IEnumerable<Reader> GetAllReaders();
        Reader GetReaderById(int id);
        void SaveReader(Reader reader);
        void DeleteReader(Reader reader);

    }
}
