using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessEntites.Utils
{
    public static class SP_Parameters
    {
        public const string HotelId = "@Id";
        public const string HotelName = "@HotelName";
        public const string HotelLocation = "@Location";
        public const string Hotel_IsActive = "@IsActive";
        public const string Hotel_InsertedValue = "@InsertedValue";
        public const string Hotel_RowCount = "@UpdatedRows";
    }
}
