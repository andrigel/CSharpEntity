using BuissnesLayer.Interfaces;
using DataLayer;
using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuissnesLayer.Implementations
{
    public class EFReaderRepository : IReaderRepository
    {
        private EFDBContext context;
        public EFReaderRepository(EFDBContext context)
        {
            this.context = context;
        }

        public void DeleteReader(Reader reader)
        {
            context.reader.Remove(reader);
            context.SaveChanges();
        }

        public IEnumerable<Reader> GetAllReaders()
        {
            return context.reader.ToList();
        }

        public Reader GetReaderById(int id)
        {
            return context.reader.FirstOrDefault(x => x.Id == id);
        }

        public void SaveReader(Reader reader)
        {
            if (reader.Id == 0)
                context.reader.Add(reader);
            else
                context.Entry(reader).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
