using AutoMapper;
using Moq;
using NOUS_challenge_app.BLL.Handlers.GenericHandlers;
using NOUS_challenge_app.BLL.Models;
using NOUS_challenge_app.BLL.Queries;
using NOUS_challenge_app.BLL.Tests.Mocks;
using NOUS_challenge_app.DAL.Entities;
using NOUS_challenge_app.DAL.Interfaces;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NOUS_challenge_app.BLL.Tests.GenericHandlersTests
{
    public class GenericGetAllQueryHandlerTest
    {
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<IGenericRepository<CleaningPlanEntity>> _repoMock =
            MockGenericRepository.GetCleaningPlanRepository();

        [Fact]
        public async Task GetCleaningPlanListTest()
        {
            _mapperMock.Setup(m => m.Map<IEnumerable<CleaningPlanModel>>(It.IsAny<List<CleaningPlanEntity>>()))
                .Returns(new List<CleaningPlanModel>());

            var handler = new GenericGetAllQueryHandler(_mapperMock.Object, _repoMock.Object);
            var result = await handler.Handle(new GenericGetAllQuery<CleaningPlanModel>(), CancellationToken.None);
            result.ShouldBeOfType<List<CleaningPlanModel>>();
        }
    }
}
