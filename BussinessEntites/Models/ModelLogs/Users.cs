using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessEntites.Models.ModelLogs
{
    public class Users
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string EmailId { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
