using Moq;
using NOUS_challenge_app.DAL.Entities;
using NOUS_challenge_app.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace NOUS_challenge_app.BLL.Tests.Mocks
{
    public class MockGenericRepository
    {
        public static Mock<IGenericRepository<CleaningPlanEntity>> GetCleaningPlanRepository()
        {
            var cleaningPlans = new List<CleaningPlanEntity>()
            {
                new CleaningPlanEntity()
                {
                    CreatedAt = DateTime.MaxValue,
                    CustomerId= 228,
                    Description = "keka",
                    Id= new Guid("bb2daac1-1bd8-420a-b009-8e8fa261c943"),
                    Title = "Kaka"
                },
                new CleaningPlanEntity()
                {
                    CreatedAt= DateTime.MinValue,
                    CustomerId= 1488,
                    Description= "fg",
                    Id = Guid.Empty,
                    Title = "lele"
                }
            };
            var mockRepo = new Mock<IGenericRepository<CleaningPlanEntity>>();
            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(cleaningPlans);
            mockRepo.Setup(x => x.CreateAsync(It.IsAny<CleaningPlanEntity>())).ReturnsAsync((CleaningPlanEntity entity) =>
              {
                  cleaningPlans.Add(entity);
                  return entity;
              });

            return mockRepo;
        }
    }
}
