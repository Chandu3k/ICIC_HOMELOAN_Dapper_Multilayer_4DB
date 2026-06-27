using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessEntites.Models.ModelLogs
{
    public class ProjectLevelErrorLog
    {
        public string StatusCode { get; set; }

        public string ErrorMessage { get; set; }

        public string StackTraceError { get; set; }

        public string InnerExceptionError { get; set; }

        public string UserName { get; set; }
    }
}
