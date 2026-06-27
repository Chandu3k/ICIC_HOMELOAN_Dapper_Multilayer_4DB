using BussinessEntites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessEntites.Interfaces.IRepository
{
    public interface IMidlandRepository
    {
        Task<List<MidlandItems>> GetMidlandItemAsync();
        Task<int> AddMidlandItemAsync(MidlandItems item);
        Task<string> UpdateMidlandItemAsync(MidlandItems item);
        Task<string> DeleteMidlandItemAsync(int id);
        Task<MidlandItems> GetMidlandItemByIdAsync(int id);
    }
}
