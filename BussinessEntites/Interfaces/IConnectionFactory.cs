using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessEntites.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection HotelsConnectionString();
        IDbConnection RestaurantConnectionString();
        IDbConnection ProductConnectionString();
        IDbConnection MidlandConnectionString();

        IDbConnection LogsConnectionString();
    }
}
