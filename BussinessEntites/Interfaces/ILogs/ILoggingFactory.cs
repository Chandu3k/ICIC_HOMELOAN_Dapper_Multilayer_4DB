using BussinessEntites.Models.ModelLogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessEntites.Interfaces.ILogs
{
    public interface ILoggingFactory
    {
        Task<bool> AddLoggingMessagesAsync(ProjectLevelLog log);
        Task<bool> ProjectLevelErrorLogAsync(ProjectLevelErrorLog errorlog);
    }
}
