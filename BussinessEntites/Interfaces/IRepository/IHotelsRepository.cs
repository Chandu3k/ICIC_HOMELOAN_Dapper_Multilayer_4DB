using BussinessEntites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessEntites.Interfaces.IRepository
{
    public interface IHotelsRepository
    {
        Task<List<Hotels>> GetAllHotels();
        Task<Hotels> GetHotelById(int id);
        Task<int> AddHotels(Hotels hotel);
        Task<string> DeleteHotelById(int id);
        Task<string> UpdateHotel(Hotels hotel);

    }
}
