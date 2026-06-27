using BussinessEntites.Interfaces;
using BussinessEntites.Interfaces.ILogs;
using BussinessEntites.Models.ModelLogs;
using BussinessEntites.Utils;
using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectivity
{
    public class LoggingFactory : ILoggingFactory
    {
        private readonly IConnectionFactory _connectionFactory;
        public LoggingFactory(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<bool> AddLoggingMessagesAsync(ProjectLevelLog log)
        {
            using(IDbConnection con= _connectionFactory.LogsConnectionString())
            {
                
                var  param = new DynamicParameters();
                param.Add(SP_Parameters.Logging_userName, log.UserName);
                param.Add(SP_Parameters.Logging_LogLevel, log.LogLevel);
                param.Add(SP_Parameters.Logging_MessageTemplate, log.MessageTemplate);
                await con.ExecuteAsync(SP_Names.ProjectLevelLog, param, commandType: CommandType.StoredProcedure);
                return true;
            }
        }

        public async Task<bool> ProjectLevelErrorLogAsync(ProjectLevelErrorLog errorlog)
        {
            using (IDbConnection con = _connectionFactory.LogsConnectionString())
            {
                var param = new DynamicParameters();
                param.Add(SP_Parameters.ErrorLog_StatusCode, errorlog.StatusCode);
                param.Add(SP_Parameters.ErrorLog_ErrorMessage, errorlog.ErrorMessage);
                param.Add(SP_Parameters.ErrorLog_StackTraceError, errorlog.StackTraceError);
                param.Add(SP_Parameters.ErrorLog_InnerExceptionError, errorlog.InnerExceptionError);
                param.Add(SP_Parameters.ErrorLog_UserName, errorlog.UserName);
                await con.ExecuteAsync(SP_Names.ProjectLevelErrorLog, param, commandType: CommandType.StoredProcedure);
                return true;
            }
        }
    }
}
