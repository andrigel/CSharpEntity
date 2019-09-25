using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Interfaces
{
    public interface ILogRepository
    {
        IEnumerable<Log> GetAllLogs(bool IncludeData = false);
        Log GetLogById(int id, bool IncludeData = false);
        void SaveLog(Log log);
        void DeleteLog(Log log);

    }
}
