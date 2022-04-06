using AutoMapper;
using MediatR;
using Moq;
using NOUS_challenge_app.BLL.Models;
using NOUS_challenge_app.BLL.Requests.CleaningPlan;
using NOUS_challenge_app.Controllers;
using NOUS_challenge_app.ViewModels;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NOUS_challenge_app.API.Tests
{
    public class CleaningPlanControllerTest
    {
        private readonly Mock<IMediator> _mediatorMock = new();
        private readonly Mock<IMapper> _mapperMock = new ();


        [Fact]
        public async Task CreateCleaningPlan_ReturnsCreatedCleaningPlanViewModel()
        {
            //Arrange
            var model = new CleaningPlanModel()
            {
                CreatedAt = DateTime.Now,
                CustomerId = 322,
                Description = "clean",
                Id = Guid.NewGuid(),
                Title = "zone"
            };

            var expectedModel = new CleaningPlanViewModel()
            {
                CreatedAt = model.CreatedAt,
                CustomerId= model.CustomerId,
                Description = model.Description,
                Id = model.Id,
                Title = model.Title,
            };
            _mediatorMock.Setup(s => s.Send(It.IsAny<CleaningPlanCreateRequest>(), CancellationToken.None))
                .Returns(Task.FromResult(model));
            _mapperMock.Setup(m => m.Map<CleaningPlanViewModel>(model))
                .Returns(expectedModel);

            var sut = new CleaningPlanController(_mediatorMock.Object, _mapperMock.Object);

            //Act
            var result = await sut.CreateCleaningPlan(model);

            //Assert
            Assert.Same(expectedModel,result);
        }


        [Fact]
        public async Task UpdateCleaningPlan_ReturnsUpdatedCleaningPlan()
        {
            //Arrange
            var model = new CleaningPlanModel()
            {
                CreatedAt = DateTime.Now,
                CustomerId = 322,
                Description = "clean",
                Id = Guid.NewGuid(),
                Title = "zone"
            };

            var expectedModel = new CleaningPlanViewModel()
            {
                CreatedAt = model.CreatedAt,
                CustomerId = model.CustomerId,
                Description = model.Description,
                Id = model.Id,
                Title = model.Title,
            };
            _mediatorMock.Setup(s => s.Send(It.IsAny<CleaningPlanUpdateRequest>(), CancellationToken.None))
                .Returns(Task.FromResult(model));
            _mapperMock.Setup(m => m.Map<CleaningPlanViewModel>(model))
                .Returns(expectedModel);

            var sut = new CleaningPlanController(_mediatorMock.Object, _mapperMock.Object);

            //Act
            var result = await sut.EditCleaningPlan(model);

            //Assert
            Assert.Same(expectedModel, result);
        }
    }
}