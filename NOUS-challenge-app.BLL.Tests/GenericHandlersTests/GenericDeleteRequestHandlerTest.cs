using AutoMapper;
using MediatR;
using Moq;
using NOUS_challenge_app.BLL.Handlers.GenericHandlers;
using NOUS_challenge_app.BLL.Models;
using NOUS_challenge_app.BLL.Requests.Generics;
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
    public class GenericDeleteRequestHandlerTest
    {
        private readonly Mock<IGenericRepository<CleaningPlanEntity>> _repoMock =
            MockGenericRepository.GetCleaningPlanRepository();

        [Fact]
        public async Task Delete_ReturnsUnit()
        {
            var handler = new GenericDeleteRequestHandler(_repoMock.Object);
            var result = await handler.Handle(new GenericDeleteRequest<CleaningPlanModel>(Guid.NewGuid()),
                CancellationToken.None);
            result.ShouldBe(Unit.Value);
        }
    }
}
