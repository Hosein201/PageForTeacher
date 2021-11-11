using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Service.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SettingApp.AutoMapper
{
    public static class AddMapper
    {
        public static void AddAutoMapperExtension(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(options => {
                options.AddProfile(new AutoMapperProfile());
                options.AllowNullCollections = true;
            });
            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);
            //services.AddAutoMapper(mapper);
        }
    }
}
