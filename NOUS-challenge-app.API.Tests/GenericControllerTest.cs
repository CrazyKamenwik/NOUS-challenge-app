using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NOUS_challenge_app.BLL.Models;
using NOUS_challenge_app.Controllers;
using System;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace NOUS_challenge_app.API.Tests
{
    public class GenericControllerTest
    {
        [Fact]
        public async Task GetByCustomerId_ReturnsOkObjectResult_WhenCustomerHasBeenFound()
        {
            var mediator = new Mock<IMediator>();

            var sut = new GenericController<CleaningPlanModel>(mediator.Object);

            var result = await sut.GetByCustomerIdAsync(It.IsAny<int>());

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsOkObjectResult_WhenCleaningPlansHasBeenFound()
        {
            //Arrange
            var mediator = new Mock<IMediator>();

            var sut = new GenericController<CleaningPlanModel>(mediator.Object);

            //Act
            var result = await sut.GetAllAsync();

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetAsync_ReturnsOkObjectResult_WhenCleaningPlanHasBeenFound()
        {
            //Arrange
            var mediator = new Mock<IMediator>();

            var sut = new GenericController<CleaningPlanModel>(mediator.Object);

            //Act
            var result = await sut.GetAsync(It.IsAny<Guid>());

            //Assert

            Assert.ThrowsAny<Exception>(() => result);
            //Should.Throw<Exception>(() => result);
            result.ShouldBeOfType<Exception>();
        }

        [Fact]
        public async Task DeleteAsync_ReturnsUnit_WhenCleaningPlanHasBeenDeleted()
        {
            //Arrange
            var mediator = new Mock<IMediator>();

            var sut = new GenericController<CleaningPlanModel>(mediator.Object);

            //Act
            var result = await sut.DeleteAsync(It.IsAny<Guid>());

            //Assert
            Assert.IsType<Unit>(result);
        }
    }
}
