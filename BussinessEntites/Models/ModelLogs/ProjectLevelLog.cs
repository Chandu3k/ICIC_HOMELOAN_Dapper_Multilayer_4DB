using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessEntites.Models.ModelLogs
{
    public class ProjectLevelLog
    {
        public string UserName { get; set; }

        public string LogLevel { get; set; }

        public string MessageTemplate { get; set; }
    }
}
