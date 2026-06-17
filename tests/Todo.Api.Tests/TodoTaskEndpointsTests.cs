using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using Todo.Api.Endpoints;
using Todo.Application.DTOs;
using Todo.Application.Interfaces.Services;

namespace Todo.Api.Tests
{
    public class TodoTaskEndpointsTests
    {
       private readonly Mock<ITodoServices> _servicesMock;

        public TodoTaskEndpointsTests()
        {
            _servicesMock = new Mock<ITodoServices>();
        }

        [Fact]
        public void TestExample()
        {
            Assert.True(true);
        }


        [Fact]
        public async Task TodoTaskEndpoints_GetItem_Returns_OK()
        {
            int id = 1;

            _servicesMock.Setup(x => x.GetTaskById(id))
                .ReturnsAsync(
                new GetTodoTaskDto
                {   Name = "name" ,
                    Id = id, 
                    IsComplete = 0
                });

            var act = await TodoTaskEndpoints.GetItem(id, _servicesMock.Object);


            Assert.NotNull(act.Result);
            Assert.IsType<Ok<GetTodoTaskDto>>(act.Result);
        }


        [Fact]
        public async Task TodoTaskEndpoints_ReturnsExpectedInstance()
        {
            int id = 1;
            var expected = new GetTodoTaskDto { Name = "Name", Id = id, IsComplete = 0 };

            _servicesMock.Setup(x => x.GetTaskById(id))
                .ReturnsAsync(expected);

            var act = await TodoTaskEndpoints.GetItem(id, _servicesMock.Object);


            Assert.NotNull(act.Result);
            Assert.Equal(expected, ((Ok<GetTodoTaskDto>)act.Result).Value);
        }


        [Fact]
        public async Task TodoTaskEndpoints_GetItem_Returns_NotFound_When_Item_Does_Not_Exist()
        {
            int id = 99;

            _servicesMock.Setup(x => x.GetTaskById(id))
                .ReturnsAsync((GetTodoTaskDto?)null);

            var act = await TodoTaskEndpoints.GetItem(id, _servicesMock.Object);

            Assert.IsType<NotFound>(act.Result);
        }


        [Fact]
        public async Task TodoTaskEndpoints_UpdateItem_Returns_NoContent_When_Item_Exists()
        {
            int id = 1;
            var dto = new UpdateTodoDto { Name = "updated", IsComplete = 1 };

            _servicesMock.Setup(x => x.UpdateTaskById(id, dto))
                .ReturnsAsync(true);

            var act = await TodoTaskEndpoints.UpdateItem(id, dto, _servicesMock.Object);

        _servicesMock.Verify(x => x.UpdateTaskById(id, dto), Times.Once);
        Assert.IsType<NoContent>(act.Result);
        }

        [Fact]
        public async Task TodoTaskEndpoints_UpdateItem_Returns_NotFound_When_Item_Does_Not_Exist()
        {
            int id = 99;
            var dto = new UpdateTodoDto { Name = "updated", IsComplete = 1 };

            _servicesMock.Setup(x => x.UpdateTaskById(id, dto))
                .ReturnsAsync(false);

            var act = await TodoTaskEndpoints.UpdateItem(id, dto, _servicesMock.Object);

            Assert.IsType<NotFound>(act.Result);
        }
    }
}
