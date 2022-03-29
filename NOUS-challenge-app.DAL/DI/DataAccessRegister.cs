using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NOUS_challenge_app.DAL.Entities;
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

            //var options = new DbContextOptionsBuilder<AppDbContext>()
            //    .UseInMemoryDatabase("CleaningPlan")
            //    .Options;

            //using var context = new AppDbContext(options);
            //var plan = new CleaningPlanEntity()
            //{
            //    CreatedAt = DateTime.Now,
            //    CustomerId = 322,
            //    Description = "hahahah",
            //    Id = Guid.NewGuid(),
            //    Title = "jgjgjgj"
            //};

            //context.CleaningPlan.Add(plan);
            //context.SaveChanges();
        }
    }
}