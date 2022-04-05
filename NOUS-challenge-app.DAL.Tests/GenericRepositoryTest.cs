using Microsoft.EntityFrameworkCore;
using Moq;
using NOUS_challenge_app.DAL.Entities;
using NOUS_challenge_app.DAL.Interfaces;
using NOUS_challenge_app.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace NOUS_challenge_app.DAL.Tests
{
    public class GenericRepositoryTest
    {
        public GenericRepositoryTest()
        {
            var cleaningPlans = new List<CleaningPlanEntity>()
            {
                new CleaningPlanEntity() { Id = new Guid("b"), CreatedAt = DateTime.Now, CustomerId = 1,
                    Description = "ak47", Title = "Clean" },
                new CleaningPlanEntity(){Id = new Guid("c"), CreatedAt = DateTime.Now, CustomerId = 2,
                    Description = "d", Title = "f"}
            };

            Mock<IGenericRepository<CleaningPlanEntity>> mockRepo = new Mock<IGenericRepository<CleaningPlanEntity>>();
            mockRepo.Setup(r => r.GetAllAsync()).Returns(cleaningPlans);
        }


        [Fact]
        public void GetByIdAsync_Returns_Product()
        {
            var repository = new Mock<IGenericRepository<CleaningPlanEntity>>();
            //Setup DbContext and DbSet mock  
            repository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns((Guid g) => ;
            var dbContextMock = new Mock<AppDbContext>();
            var dbSetMock = new Mock<DbSet<CleaningPlanEntity>>();
            dbSetMock.Setup(s => s.FindAsync(It.IsAny<Guid>())).Returns(ValueTask.FromResult(new CleaningPlanEntity()));
            dbContextMock.Setup(s => s.Set<CleaningPlanEntity>()).Returns(dbSetMock.Object);

            //Execute method of SUT (ProductsRepository)  
            var productRepository = new GenericRepository<CleaningPlanEntity>(dbContextMock.Object);
            var product = productRepository.GetByIdAsync(Guid.NewGuid()).Result;

            //Assert  
            Assert.NotNull(product);
            Assert.IsAssignableFrom<CleaningPlanEntity>(product);
        }

    }
}
