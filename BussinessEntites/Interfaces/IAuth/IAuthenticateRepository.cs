using BussinessEntites.Dtos.AuthDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessEntites.Interfaces.IAuth
{
    public interface IAuthenticateRepository
    {
        Task<UserSignInResponse> UserSignIn(LoginDto loginDTOObj);
        Task<UserRoleInformationResponse> GetUserRolesInformation(LoginDto loginDTOObj);

    }
}
