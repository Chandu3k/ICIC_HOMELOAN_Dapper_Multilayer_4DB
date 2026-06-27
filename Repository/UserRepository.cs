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
    public class UserRepository : IUserRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public UserRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<UserSignInResponse> UserResgistration(Users usersObj)
        {
            using (IDbConnection con = _connectionFactory.LogsConnectionString())
            {
                var encyptedPassword = EncryptionLibrary.EncryptText(usersObj.Password);

                var p = new DynamicParameters();
                p.Add(SP_Parameters.UserName, usersObj.UserName);
                p.Add(SP_Parameters.Password, encyptedPassword);
                p.Add(SP_Parameters.EmailId, usersObj.EmailId);
                p.Add(SP_Parameters.PhoneNumber, usersObj.PhoneNumber);
                p.Add(SP_Parameters.Address, usersObj.Address);
                p.Add(SP_Parameters.IsActive, usersObj.IsActive);

                var rows = await con.ExecuteAsync(
                    SP_Names.UserRegistration,
                    p,
                    commandType: CommandType.StoredProcedure);

                return rows > 0
                    ? new UserSignInResponse
                    {
                        StatusCode = "200",
                        StatusMessage = "User Registration Successful"
                    }
                    : new UserSignInResponse
                    {
                        StatusCode = "500",
                        StatusMessage = "User Registration Failed"
                    };
            }
        }

        public async Task<UserSignInResponse> UserRolesMapping(UserRole userRoleObj)
        {
            using (IDbConnection con = _connectionFactory.LogsConnectionString())
            {
                var p = new DynamicParameters();
                p.Add(SP_Parameters.UserRole_UserId, userRoleObj.UserId);
                p.Add(SP_Parameters.UserRole_RoleId, userRoleObj.RoleId);
                var result = await con.ExecuteAsync(SP_Names.UserRoleRegistration, p, commandType: CommandType.StoredProcedure);
                return result > 0 ? new UserSignInResponse { StatusCode = "200", StatusMessage = "User Role Mapping Successful" } : new UserSignInResponse { StatusCode = "500", StatusMessage = "User Role Mapping Failed" };
            }
        }
    }
}
