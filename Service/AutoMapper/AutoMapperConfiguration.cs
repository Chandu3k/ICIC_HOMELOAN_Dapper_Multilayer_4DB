using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            var mapperConfig = new MapperConfiguration(config =>
                {
                    config.AddProfile<AutoMapperProfile>();
                });
            return mapperConfig;
        }

    }
}
