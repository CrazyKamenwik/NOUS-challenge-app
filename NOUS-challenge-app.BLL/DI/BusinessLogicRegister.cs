using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NOUS_challenge_app.BLL.Mapper;
using NOUS_challenge_app.DAL.DI;

namespace NOUS_challenge_app.BLL.DI
{
    public static class BusinessLogicRegister
    {
        public static void AddBusinessLogic(this IServiceCollection services)
        {
            services.AddDataRegister();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddMediatR(typeof(BusinessLogicRegister).Assembly);

            //var mapperConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new MappingProfile());
            //});

            //IMapper mapper = mapperConfig.CreateMapper();
            //services.AddSingleton(mapper);
        }
    }
}
