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
    public class HotelsService : IHotelsServices
    {
        private readonly IHotelsRepository _hotelsRepository;
        private readonly IMapper _mapper;
        public HotelsService(IHotelsRepository hotelsRepository, IMapper mapper)
        {
            _hotelsRepository = hotelsRepository;
            _mapper = mapper;
        }
        public async Task<int> AddHotels(HotelsDto hoteldto)
        {
            var hotels=_mapper.Map<Hotels>(hoteldto);
            return await _hotelsRepository.AddHotels(hotels);
        }

        public async Task<string> DeleteHotelById(int id)
        {
            string result = await _hotelsRepository.DeleteHotelById(id);
            return result;
        }

        public async Task<List<HotelsDto>> GetAllHotels()
        {
            var hotels = await _hotelsRepository.GetAllHotels();
            var hotelsDto = _mapper.Map<List<HotelsDto>>(hotels);
            return hotelsDto;
        }

        public async Task<HotelsDto> GetHotelById(int id)
        {
            var hotel= await _hotelsRepository.GetHotelById(id);
            if (hotel == null)
            {
                return null;
            }
            else
            {
                var hotelDto = _mapper.Map<HotelsDto>(hotel);
                return hotelDto;
            }
        }

        public async Task<string> UpdateHotel(HotelsDto hotel)
        {   
            var prama= _mapper.Map<Hotels>(hotel);
            string result = await _hotelsRepository.UpdateHotel(prama);
            return result;
        }
    }
}
