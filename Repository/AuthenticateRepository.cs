using BussinessEntites.Dtos.AuthDto;
using BussinessEntites.Interfaces;
using BussinessEntites.Interfaces.IAuth;
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
    public class AuthenticateRepository : IAuthenticateRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public AuthenticateRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<UserRoleInformationResponse> GetUserRolesInformation(LoginDto loginDTOObj)
        {
            using(IDbConnection con = _connectionFactory.LogsConnectionString())
            {
                var p = new DynamicParameters();
                p.Add(SP_Parameters.Login_UserName, loginDTOObj.UserName);
                var result = await con.QueryAsync<UserRoleInformationResponse>(SP_Names.GetUserRolesInformation, p, commandType: CommandType.StoredProcedure);
                var status = result.FirstOrDefault();
                return status;
            }
        }

        public async Task<UserSignInResponse> UserSignIn(LoginDto loginDTOObj)
        {
            using(IDbConnection con = _connectionFactory.LogsConnectionString())
            {
                var encrypttext=EncryptionLibrary.EncryptText(loginDTOObj.Password);
                var p = new DynamicParameters();
                p.Add(SP_Parameters.Login_UserName, loginDTOObj.UserName);
                p.Add(SP_Parameters.Login_Password, encrypttext);
                var result = await con.QueryAsync<UserSignInResponse>(SP_Names.SignIn, p, commandType: CommandType.StoredProcedure);
                var status = result.FirstOrDefault();
                return status;
            }
        }
    }
}
