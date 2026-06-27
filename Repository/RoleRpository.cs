using BussinessEntites.Dtos.AuthDto;
using BussinessEntites.Interfaces;
using BussinessEntites.Interfaces.IAuth;
using BussinessEntites.Models.ModelLogs;
using BussinessEntites.Utils;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RoleRpository:IRolesRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public RoleRpository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<UserSignInResponse> RolesCreation(Roles rolesObj)
        {
            using(IDbConnection con= _connectionFactory.LogsConnectionString())
            {
                var p = new DynamicParameters();
                p.Add(SP_Parameters.RoleName, rolesObj.RoleName);
                p.Add(SP_Parameters.IsActive, rolesObj.IsActive);
                var result = await con.QuerySingleAsync<UserSignInResponse>(SP_Names.RoleRegistration, p, commandType: CommandType.StoredProcedure);
                return result = new UserSignInResponse
                {
                    StatusCode = result.StatusCode,
                    StatusMessage = result.StatusMessage
                };

            }
        }
    }
}
