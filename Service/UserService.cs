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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserSignInResponse> UserResgistration(UserDto usersObj)
        {
            Users user = new Users();
            user.UserName = usersObj.UserName;
            user.Password = usersObj.Password;
            user.EmailId = usersObj.EmailId;
            user.PhoneNumber = usersObj.PhoneNumber;
            user.Address = usersObj.Address;
            user.IsActive = usersObj.IsActive;
            var result = await _userRepository.UserResgistration(user);
            return result;
        }

        public async Task<UserSignInResponse> UserRolesMapping(UserRoleDto userRoleDTOObj)
        {
            UserRole userRole = new UserRole();
            userRole.UserId = userRoleDTOObj.UserId;
             userRole.RoleId = userRoleDTOObj.RoleId;
            var result = await _userRepository.UserRolesMapping(userRole);
            return result;
        }
    }
}
