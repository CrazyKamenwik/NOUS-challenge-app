using AutoMapper;
using MediatR;
using Moq;
using NOUS_challenge_app.BLL.Models;
using NOUS_challenge_app.BLL.Requests.CleaningPlan;
using NOUS_challenge_app.Controllers;
using NOUS_challenge_app.Mapper;
using NOUS_challenge_app.ViewModels;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NOUS_challenge_app.API.Tests
{
    public class CleaningPlanControllerTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly IMapper _mapper;

        public CleaningPlanControllerTest(Mock<IMediator> mediatorMock, IMapper mapper)
        {
            _mediatorMock = mediatorMock;
            _mapper = mapper;

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task CreateCleaningPlan_ReturnsCreatedCleaningPlanViewModel()
        {
            var model = new CleaningPlanModel()
            {
                CreatedAt = DateTime.Now,
                CustomerId = 322,
                Description = "clean",
                Id = Guid.NewGuid(),
                Title = "zone"
            };

            _mediatorMock.Setup(s => s.Send(It.IsAny<CleaningPlanCreateRequest>(), CancellationToken.None))
                .Returns(Task.FromResult(model));

            var sut = new CleaningPlanController(_mediatorMock.Object, _mapper);
            var result = await sut.CreateCleaningPlan(It.IsAny<CleaningPlanModel>());
            var viewModel = _mapper.Map<CleaningPlanViewModel>(result);

            Assert.IsType<CleaningPlanModel>(viewModel);
        }


        [Fact]
        public async Task UpdateCleaningPlan_ReturnsUpdatedCleaningPlan()
        {
            var model = new CleaningPlanModel()
            {
                CreatedAt = DateTime.Now,
                CustomerId = 228,
                Description = "djdj",
                Id = Guid.NewGuid(),
                Title = "ooo"
            };

            _mediatorMock.Setup(s => s.Send(It.IsAny<CleaningPlanUpdateRequest>(), CancellationToken.None))
                .Returns(Task.FromResult(model));

            var sut = new CleaningPlanController(_mediatorMock.Object, _mapper);
            var result = await sut.CreateCleaningPlan(It.IsAny<CleaningPlanModel>());
            var viewModel = _mapper.Map<CleaningPlanViewModel>(result);

            Assert.IsType<CleaningPlanModel>(viewModel);
        }
    }
}