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
        public static void InitializeMap(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(config =>
                {
                    config.AddProfile<AutoMapperProfile>();
                });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

    }
}
