using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.DTOs;
using Todo.Application.Interfaces.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Todo.Api.Endpoints
{
    public static class TodoTaskEndpoints
    {

       
        public static WebApplication MapTodoEndpoints(this WebApplication app)
        {

            var group = app.MapGroup("/api/todotasks");

            group.MapGet("{id:int}", GetItem)
              .ProducesProblem(StatusCodes.Status500InternalServerError);

            group.MapPut("{id:int}", UpdateItem)
                 .ProducesValidationProblem()
                 .ProducesProblem(StatusCodes.Status500InternalServerError);

            group.MapPost("/", Create)
                .Accepts<CreateTodoTaskDto>("application/json")
                .Produces<TodoItemResponse>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest)
                .ProducesProblem(StatusCodes.Status500InternalServerError);


            group.MapDelete("{id:int}", DeleteItem)
               .Produces(StatusCodes.Status204NoContent)
             .ProducesProblem(StatusCodes.Status500InternalServerError);


            return app;
        }

        public static async Task<Results<Ok<GetTodoTaskDto>, NotFound>> GetItem(int id, ITodoServices service)
        {
            var itemTask = await service.GetTaskById(id);

            if(itemTask == null) { return TypedResults.NotFound(); }

            return TypedResults.Ok(itemTask);
        }
        

        public static async Task<Created> Create(CreateTodoTaskDto createTodoTaskDto,
            [FromServices]  ITodoServices todoServices)
        {
            await todoServices.CreateTask(createTodoTaskDto);
            return TypedResults.Created();
        }
        public static async Task<Results<NoContent, NotFound>> UpdateItem(
                     int id,
                     UpdateTodoDto updateToDoTask,
                      [FromServices] ITodoServices todoServices
                               )
        {
            if (!await todoServices.UpdateTaskById(id, updateToDoTask))
            {
                return TypedResults.NotFound();
            }

            return TypedResults.NoContent();
        }

        public static async Task<Results<NoContent, NotFound>> DeleteItem(
        int id,
        [FromServices] ITodoServices todoServices)
        {
            var result = await todoServices.DeleteTask(id);

            if(result == true) return TypedResults.NotFound();
          
            return TypedResults.NoContent();
        }
    }
}
