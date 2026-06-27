using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessEntites.Models.ModelLogs
{
    public class Roles
    {
        public int Id { get; set; }

        public string RoleName { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
