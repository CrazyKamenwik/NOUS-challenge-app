using Microsoft.EntityFrameworkCore;
using NOUS_challenge_app.DAL.Entities;
using NOUS_challenge_app.DAL.Interfaces;
using NOUS_challenge_app.DAL.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;

namespace NOUS_challenge_app.DAL.Tests
{
    public class GenericRepositoryTest
    {
        public GenericRepositoryTest()
        {
        }

        [Fact]
        public async Task CreateAsync_ReturnsCreatedCleaningPlan()
        {
            IGenericRepository<CleaningPlanEntity> sut = GetInMemoryGenericRepository();
            CleaningPlanEntity cleaningPlan = new CleaningPlanEntity()
            {
                CreatedAt = DateTime.Now,
                CustomerId = 322,
                Description = "Clean cumzone",
                Id = Guid.NewGuid(),
                Title = "Cumzone cleaning"
            };

            CleaningPlanEntity savedPlan = await sut.CreateAsync(cleaningPlan);
            Assert.NotNull(savedPlan);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsListOfCleaningPlans()
        {
            IGenericRepository<CleaningPlanEntity> sut = GetInMemoryGenericRepository();
            await sut.GetAllAsync();
        }

        [Fact]
        public async Task DeleteAsync_ReturnsTask()
        {
            IGenericRepository<CleaningPlanEntity> sut = GetInMemoryGenericRepository();
            await sut.DeleteAsync(Guid.NewGuid());
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsCleaningPlan()
        {
            IGenericRepository<CleaningPlanEntity> sut = GetInMemoryGenericRepository();
            await sut.GetByIdAsync(Guid.NewGuid());
        }

        [Fact]
        public async Task GetByCustomerIdAsync_ReturnsCleaningPlan()
        {
            IGenericRepository<CleaningPlanEntity> sut = GetInMemoryGenericRepository();
            await sut.GetByCustomerIdAsync(int.MinValue);
        }

        [Fact]
        public async Task UpdateAsync_ReturnsUpdatedCleaningPlan()
        {
            IGenericRepository<CleaningPlanEntity> sut = GetInMemoryGenericRepository();
            var id = new Guid("f7c27853-2f45-4283-bc1c-86a9dde341b1");
            CleaningPlanEntity expected = new CleaningPlanEntity()
            {
                CreatedAt = DateTime.Now,
                CustomerId = 322,
                Description = "Clean cumzone",
                Id = id,
                Title = "Cumzone cleaning"
            };
            var plan = await sut.GetByIdAsync(id);
            plan.Description = expected.Description;
            plan.CustomerId = expected.CustomerId;
            plan.Title = expected.Title;
            await sut.UpdateAsync(plan);
            Assert.Equal(expected.Description, plan.Description);
            Assert.Equal(expected.CustomerId, plan.CustomerId);
            Assert.Equal(expected.Title, plan.Title);
        }

        private IGenericRepository<CleaningPlanEntity> GetInMemoryGenericRepository()
        {
            DbContextOptions<AppDbContext> options;
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseInMemoryDatabase("CleaningPlan");
            options = builder.Options;
            AppDbContext dbContext = new AppDbContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            var cleaningPlan = new CleaningPlanEntity()
            {
                CreatedAt = DateTime.Now,
                CustomerId = 1,
                Description = "Lele",
                Id = new Guid("f7c27853-2f45-4283-bc1c-86a9dde341b1"),
                Title = "heheHaha"
            };
            dbContext.Add(cleaningPlan);
            dbContext.SaveChangesAsync();
            return new GenericRepository<CleaningPlanEntity>(dbContext);
        }

    }
}
