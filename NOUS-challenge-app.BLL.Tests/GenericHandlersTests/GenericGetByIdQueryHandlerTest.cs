using AutoMapper;
using Moq;
using NOUS_challenge_app.BLL.Handlers.GenericHandlers;
using NOUS_challenge_app.BLL.Models;
using NOUS_challenge_app.BLL.Queries;
using NOUS_challenge_app.BLL.Tests.Mocks;
using NOUS_challenge_app.DAL.Entities;
using NOUS_challenge_app.DAL.Interfaces;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NOUS_challenge_app.BLL.Tests.GenericHandlersTests
{
    public class GenericGetByIdQueryHandlerTest
    {
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<IGenericRepository<CleaningPlanEntity>> _repoMock
            = MockGenericRepository.GetCleaningPlanRepository();


        [Fact]
        public async Task GetById_ReturnsCleaningPlanModel()
        {
            _mapperMock.Setup(m => m.Map<CleaningPlanModel>(It.IsAny<CleaningPlanEntity>()))
                .Returns(new CleaningPlanModel());
            var handler = new GenericGetByIdQueryHandler(_mapperMock.Object, _repoMock.Object);
            var result = await handler.Handle(new GenericGetByIdQuery<CleaningPlanModel>(Guid.Empty),
                CancellationToken.None);
            result.ShouldBeOfType<CleaningPlanModel>();
        }
    }
}
