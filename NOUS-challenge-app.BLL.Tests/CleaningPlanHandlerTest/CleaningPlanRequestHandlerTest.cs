using AutoMapper;
using Moq;
using NOUS_challenge_app.BLL.Handlers.CleaningPlanHandlers;
using NOUS_challenge_app.BLL.Mapper;
using NOUS_challenge_app.BLL.Models;
using NOUS_challenge_app.BLL.Requests.CleaningPlan;
using NOUS_challenge_app.BLL.Tests.Mocks;
using NOUS_challenge_app.DAL.Entities;
using NOUS_challenge_app.DAL.Interfaces;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NOUS_challenge_app.BLL.Tests.CleaningPlanHandlerTest
{
    public class CleaningPlanRequestHandlerTest
    {
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<IGenericRepository<CleaningPlanEntity>> _repoMock;

        public CleaningPlanRequestHandlerTest()
        {
            _repoMock = MockGenericRepository.GetCleaningPlanRepository();

            _mapperMock.Setup(m => m.Map<CleaningPlanModel>(It.IsAny<CleaningPlanEntity>()))
                            .Returns(new CleaningPlanModel());
        }

        [Fact]
        public async Task CreateCleaningPlan_ReturnsCreatedCleaningPlan()
        {
            var model = new CleaningPlanModel()
            {
                CreatedAt = DateTime.Now,
                CustomerId = 228,
                Description = "kee",
                Id = Guid.NewGuid(),
                Title = "title"
            };
            var handler = new CleaningPlanRequestHandler(_repoMock.Object, _mapperMock.Object);
            var result = await handler.Handle(new CleaningPlanCreateRequest(model), CancellationToken.None);
            result.ShouldBeOfType<CleaningPlanModel>();
        }


        [Fact]
        public async Task UpdateCleaningPlan_ReturnsUpdatedCleaningPlan()
        {
            var model = new CleaningPlanModel()
            {
                CreatedAt = DateTime.Now,
                CustomerId = 322,
                Description = "eee",
                Id = Guid.Empty,
                Title = "www"
            };
            var handler = new CleaningPlanRequestHandler(_repoMock.Object, _mapperMock.Object);
            var result = await handler.Handle(new CleaningPlanUpdateRequest(model), CancellationToken.None);
            result.ShouldBeOfType<CleaningPlanModel>();
        }
    }
}
