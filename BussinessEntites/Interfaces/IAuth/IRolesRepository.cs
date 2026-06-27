using BussinessEntites.Dtos.AuthDto;
using BussinessEntites.Models.ModelLogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessEntites.Interfaces.IAuth
{
    public interface IRolesRepository
    {
        Task<UserSignInResponse> RolesCreation(Roles rolesObj);

    }
}
