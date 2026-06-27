using BussinessEntites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessEntites.Interfaces.IRepository
{
    public interface IRestaurantRepository
    {
        Task<List<Restaurant>> GetAllRestaurant();
        Task<Restaurant> GetRestaurantById(int id);
        Task<int> AddRestaurant(Restaurant restaurant);
        Task<string> UpdateRestaurant(Restaurant restaurant);
        Task<string> DeleteRestaurant(int id);
    }
}
