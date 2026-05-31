using AutoMapper;
using BussinessEntites.Dtos;
using BussinessEntites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Hotels,HotelsDto>();
            CreateMap<HotelsDto, Hotels>();

            CreateMap<Restaurant, RestaurantDto>().ReverseMap();
        }
    }
}
