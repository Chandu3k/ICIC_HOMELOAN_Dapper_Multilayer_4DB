using BussinessEntites.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessEntites.Interfaces.IServices
{
    public interface IMidlandService
    {
        Task<List<MidlandItemsDto>> GetMidlandItemAsync();
        Task<int> AddMidlandItemAsync(MidlandItemsDto item);
        Task<string> UpdateMidlandItemAsync(MidlandItemsDto item);
        Task<string> DeleteMidlandItemAsync(int id);
        Task<MidlandItemsDto> GetMidlandItemByIdAsync(int id);
    }
}
