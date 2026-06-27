using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessEntites.Dtos.AuthDto
{
    public class UserLoginResponse
    {
        public string Message { get; set; }

        public string AccessToken { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }
    }
}
