using AutoMapper;
using Moq;
using NOUS_challenge_app.BLL.Handlers.GenericHandlers;
using NOUS_challenge_app.BLL.Mapper;
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

namespace NOUS_challenge_app.BLL.Tests
{
    public class GenericGetAllQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IGenericRepository<CleaningPlanEntity>> _mockRepo;

        public GenericGetAllQueryHandlerTest()
        {
            _mockRepo = MockGenericRepository.GetCleaningPlanRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetCleaningPlanListTest()
        {
            var handler = new GenericGetAllQueryHandler(_mapper, _mockRepo.Object);
            var result = await handler.Handle(new GenericGetAllQuery<CleaningPlanModel>(), CancellationToken.None);
            result.ShouldBeOfType<List<CleaningPlanModel>>();
            result.Count().ShouldBe(2);
        }
    }
}
