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
        private readonly Mock<IMediator> _mockMediator = new();

        [Fact]
        public async Task GetByCustomerId_ReturnsOkObjectResult_WhenCustomerHasBeenFound()
        {
            var sut = new GenericController<CleaningPlanModel>(_mockMediator.Object);

            var result = await sut.GetByCustomerIdAsync(It.IsAny<int>());

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsOkObjectResult_WhenCleaningPlansHasBeenFound()
        {
            //Arrange
            var sut = new GenericController<CleaningPlanModel>(_mockMediator.Object);

            //Act
            var result = await sut.GetAllAsync();

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetAsync_ReturnsException_WhenCleaningPlanHasNotBeenFound()
        {
            //Arrange
            var sut = new GenericController<CleaningPlanModel>(_mockMediator.Object);

            //Assert

            Assert.ThrowsAny<Exception>(() => sut.GetAsync(It.IsAny<Guid>()).Result);
        }

        [Fact]
        public async Task DeleteAsync_ReturnsUnit_WhenCleaningPlanHasBeenDeleted()
        {
            //Arrange
            var sut = new GenericController<CleaningPlanModel>(_mockMediator.Object);

            //Act
            var result = await sut.DeleteAsync(It.IsAny<Guid>());

            //Assert
            Assert.IsType<Unit>(result);
        }
    }
}
