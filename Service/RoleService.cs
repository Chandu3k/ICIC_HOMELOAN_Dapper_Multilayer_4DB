using AutoMapper;
using BussinessEntites.Dtos.AuthDto;
using BussinessEntites.Interfaces.IAuth;
using BussinessEntites.Models.ModelLogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RoleService : IRolesService
    {
        private readonly IRolesRepository _rolesRepository;
        private readonly IMapper _mapper;

        public RoleService(IRolesRepository rolesRepository, IMapper mapper)
        {
            _rolesRepository = rolesRepository;
            _mapper = mapper;
        }
        public async Task<UserSignInResponse> RolesCreation(RoleDto rolesObj)
        {
            Roles roles = new Roles();
            roles.RoleName= rolesObj.RoleName;
            roles.IsActive = rolesObj.IsActive;
            var result = await _rolesRepository.RolesCreation(roles);
            return result;
        }
    }
}
