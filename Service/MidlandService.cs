using AutoMapper;
using BussinessEntites.Dtos;
using BussinessEntites.Interfaces;
using BussinessEntites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MidlandService : IMidlandService
    {
        private readonly IMidlandRepository _midlandRepository;
        private readonly IMapper _mapper;
        public MidlandService(IMidlandRepository midlandRepository, IMapper mapper)
        {
            _midlandRepository = midlandRepository;
            _mapper = mapper;
        }
        public async Task<int> AddMidlandItemAsync(MidlandItemsDto item)
        {
           var result = _mapper.Map<MidlandItems>(item);
            return await _midlandRepository.AddMidlandItemAsync(result);
        }

        public async Task<string> DeleteMidlandItemAsync(int id)
        {
            return await _midlandRepository.DeleteMidlandItemAsync(id);
        }

        public async Task<List<MidlandItemsDto>> GetMidlandItemAsync()
        {
            var result = await _midlandRepository.GetMidlandItemAsync();
            return _mapper.Map<List<MidlandItemsDto>>(result);
        }

        public async Task<MidlandItemsDto> GetMidlandItemByIdAsync(int id)
        {
            var result = await _midlandRepository.GetMidlandItemByIdAsync(id);
            return _mapper.Map<MidlandItemsDto>(result);
        }

        public async Task<string> UpdateMidlandItemAsync(MidlandItemsDto item)
        {
            var result = _mapper.Map<MidlandItems>(item);
            return await _midlandRepository.UpdateMidlandItemAsync(result);
        }
    }
}
