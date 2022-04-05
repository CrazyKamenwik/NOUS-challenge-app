using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NOUS_challenge_app.DAL.Interfaces;
using NOUS_challenge_app.DAL.Repositories;

namespace NOUS_challenge_app.DAL.DI
{
    public static class DataAccessRegister
    {
        public static void AddDataRegister(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(
                opt =>
                    opt.UseInMemoryDatabase("CleaningPlan"));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}