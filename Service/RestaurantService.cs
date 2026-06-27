using AutoMapper;
using BussinessEntites.Dtos;
using BussinessEntites.Interfaces.IRepository;
using BussinessEntites.Interfaces.IServices;
using BussinessEntites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;
        public RestaurantService(IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }
        public async Task<int> AddRestaurant(RestaurantDto restaurant)
        {
            var restaurantEntity = _mapper.Map<Restaurant>(restaurant);
            return await _restaurantRepository.AddRestaurant(restaurantEntity);
        }

        public async Task<string> DeleteRestaurant(int id)
        {
            string result = await _restaurantRepository.DeleteRestaurant(id);
            return result;
        }

        public async Task<List<RestaurantDto>> GetAllRestaurant()
        {
            var restaurantEntities = await _restaurantRepository.GetAllRestaurant();
            var restaurantDtos = _mapper.Map<List<RestaurantDto>>(restaurantEntities);
            return restaurantDtos;
        }

        public async Task<RestaurantDto> GetRestaurantById(int id)
        {
            var restaurantEntity = await _restaurantRepository.GetRestaurantById(id);
            if (restaurantEntity == null)
            {
                return null;
            }
            var restaurantDto = _mapper.Map<RestaurantDto>(restaurantEntity);
            return restaurantDto;
        }

        public async Task<string> UpdateRestaurant(RestaurantDto restaurant)
        {
            var restaurantEntity = _mapper.Map<Restaurant>(restaurant);
            string result = await _restaurantRepository.UpdateRestaurant(restaurantEntity);
            return result;
        }
    }
}
