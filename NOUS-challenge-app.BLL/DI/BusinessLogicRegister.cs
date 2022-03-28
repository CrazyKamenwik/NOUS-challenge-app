using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NOUS_challenge_app.BLL.Mapper;
using NOUS_challenge_app.DAL.DI;
using AutoMapper;

namespace NOUS_challenge_app.BLL.DI
{
    public static class BusinessLogicRegister
    {
        public static void AddBusinessLogic(IServiceCollection services, IConfiguration config)
        {
            services.AddDataRegister(config);
            
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

        }
    }
}
