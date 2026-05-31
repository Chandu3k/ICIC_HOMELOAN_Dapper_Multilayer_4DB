using BussinessEntites.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessEntites.Interfaces
{
    public interface IRestaurantService
    {
        Task<List<RestaurantDto>> GetAllRestaurant();
        Task<RestaurantDto> GetRestaurantById(int id);
        Task<int> AddRestaurant(RestaurantDto restaurant);
        Task<string> UpdateRestaurant(RestaurantDto restaurant);
        Task<string> DeleteRestaurant(int id);
    }
}
