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
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NOUS_challenge_app.BLL.Tests.GenericHandlersTests
{
    public class GenericGetByCustomerIdQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IGenericRepository<CleaningPlanEntity>> _mockRepo;

        public GenericGetByCustomerIdQueryHandlerTest()
        {
            _mockRepo = MockGenericRepository.GetCleaningPlanRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetByCustomerId_ReturnsCleaningPlanListAttachedToACustomer()
        {
            var handler = new GenericGetByCustomerIdQueryHandler(_mockRepo.Object, _mapper);
            var result = await handler.Handle(new GenericGetByCustomerIdQuery<CleaningPlanModel>(It.IsAny<int>()),
                CancellationToken.None);
            result.ShouldBeOfType<List<CleaningPlanModel>>();
        }
    }
}
