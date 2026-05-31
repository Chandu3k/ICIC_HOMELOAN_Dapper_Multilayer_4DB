using BussinessEntites.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessEntites.Interfaces
{
    public interface IHotelsServices
    {
        Task<List<HotelsDto>> GetAllHotels();
        Task<HotelsDto> GetHotelById(int id);
        Task<int> AddHotels(HotelsDto hotel);
        Task<string> DeleteHotelById(int id);
        Task<string> UpdateHotel(HotelsDto hotel);
    }
}
