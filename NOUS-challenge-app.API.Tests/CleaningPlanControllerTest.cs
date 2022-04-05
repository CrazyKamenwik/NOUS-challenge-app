using AutoMapper;
using MediatR;
using Moq;
using NOUS_challenge_app.BLL.Models;
using NOUS_challenge_app.BLL.Requests.CleaningPlan;
using NOUS_challenge_app.Controllers;
using System;
using System.Threading.Tasks;
using Xunit;

namespace NOUS_challenge_app.API.Tests
{
    public class CleaningPlanControllerTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<IMapper> _mapperMock;

        //[Fact]
        //public async Task CreateCleaningPlan_ReturnsCreatedCleaningPlanViewModel()
        //{
        //    var mediator = new Mock<IMediator>();
        //    var mapper = new Mock<IMapper>();
        //    var model = new CleaningPlanModel()
        //    {
        //        CreatedAt = DateTime.Now,
        //        CustomerId = 322,
        //        Description = "clean",
        //        Id = Guid.NewGuid(),
        //        Title = "zone"
        //    };

        //    await mediator.Setup(s => s.Send().Return(model);

        //    var sut = new CleaningPlanController(mediator.Object, mapper.Object);
        //    //var result = await sut.CreateCleaningPlan(It.IsAny<>());


        //    Assert.IsType<HttpNotFoundResult>(result);
        //}


        //[Fact]
        //public async void CleaningPlanCreate_SendCreateCleaningPlanRequest()
        //{
        //    var id = Guid.NewGuid();
        //    var cleaningPlan = new CleaningPlanModel()
        //    {
        //        CreatedAt = DateTime.Now, 
        //        CustomerId = 322, 
        //        Description = "Clean the semen",
        //        Id = id,
        //        Title = "The semen cleaning"
        //    };
        //    var mediator = new Mock<IMediator>();
        //    //var sut = new CleaningPlanController(_mediatorMock.Object, _mapperMock.Object);

        //    //await sut.CreateCleaningPlan(cleaningPlan);

        //    mediator.Setup(x=>x.Send(It.IsAny<CleaningPlanModel>())).Returns(cleaningPlan);
        //}




        //[Theory]
        //[InlineData(new CleaningPlanModel()
        //    {CustomerId = 1, Description = "hehe", Title = "haha"})]
        //public async Task SendCreateRequest_ReturnsCreatedViewModel(CleaningPlanModel model)
        //{
        //    var fakeMediator = new Mock<IMediator>();
        //    var fakeResult = new CleaningPlanViewModel()
        //    {
        //        CustomerId = 322,
        //        Title = "clean",
        //        CreatedAt = DateTime.Now,
        //        Description = "Clean",
        //        Id = Guid.NewGuid()
        //    };

        //    //var mediator = new Mediator(fakeMediator.Object);
        //    mediatorMock
        //        .Setup(s =>
        //            s.Send(It.IsAny<CleaningPlanCreateRequest>(CleaningPlanModel)).Result());
        //}
    }
}