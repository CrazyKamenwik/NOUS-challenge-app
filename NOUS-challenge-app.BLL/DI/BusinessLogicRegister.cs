using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NOUS_challenge_app.BLL.Mapper;
using NOUS_challenge_app.DAL.DI;
using AutoMapper;
using MediatR;

namespace NOUS_challenge_app.BLL.DI
{
    public static class BusinessLogicRegister
    {
        public static void AddBusinessLogic(this IServiceCollection services)
        {
            services.AddDataRegister();
            
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            //services.AddMediatR();
        }
    }
}
