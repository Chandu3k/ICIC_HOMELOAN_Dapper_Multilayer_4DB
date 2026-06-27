using BussinessEntites.Dtos.AuthDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessEntites.Interfaces.IAuth
{
    public interface IUserService
    {
        Task<UserSignInResponse> UserResgistration(UserDto usersObj);
        Task<UserSignInResponse> UserRolesMapping(UserRoleDto userRoleDTOObj);
    }
}
