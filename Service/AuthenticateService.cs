using BussinessEntites.Dtos.AuthDto;
using BussinessEntites.Interfaces.IAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IAuthenticateRepository _authenticateRepository;
        public AuthenticateService(IAuthenticateRepository authenticateRepository)
        {
            _authenticateRepository = authenticateRepository;
        }
        public async Task<UserRoleInformationResponse> GetUserRolesInformation(LoginDto loginDTOObj)
        {
            var result = await _authenticateRepository.GetUserRolesInformation(loginDTOObj);
            return result;
        }

        public async Task<UserSignInResponse> UserSignIn(LoginDto loginDTOObj)
        {
            var result = await _authenticateRepository.UserSignIn(loginDTOObj);
            return result;
        }
    }
}
