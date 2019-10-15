using BuissnesLayer.Interfaces;
using DataLayer;
using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdoNet;

namespace BuissnesLayer.Implementations
{
    public class EFLogRepository : ILogRepository
    {
        private EFDBContext context;
        public EFLogRepository(EFDBContext context)
        {
            this.context = context;
        }

        public void DeleteLog(Log log)
        {
            context.log.Remove(log);
            context.SaveChanges();
        }

        public IEnumerable<Log> GetAllLogs(bool IncludeData = false)
        {
            if (IncludeData)
                return context.Set<Log>().Include(x => x.Book).Include(y=> y.Reader).AsNoTracking().ToList();
            else
                return context.log.ToList();
        }

        public Log GetLogById(int id, bool IncludeData = false)
        {
            if (IncludeData)
                return context.Set<Log>().Include(x => x.Book).Include(y => y.Reader).AsNoTracking().FirstOrDefault(x => x.Id == id);
            else
                return context.log.FirstOrDefault(x => x.Id == id);
        }

        public void SaveLog(Log log)
        {
            if (log.Id == 0)
                context.log.Add(log);
            else
                context.Entry(log).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

    }
}
