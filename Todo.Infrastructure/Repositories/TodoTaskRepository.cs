using Microsoft.EntityFrameworkCore;
using Todo.Application.DTOs;
using Todo.Application.Interfaces.Repositories;
using Todo.Infrastructure.Data;

namespace Todo.Infrastructure.Repositories
{
    public class TodoTaskRepository : ITodoTaskRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public TodoTaskRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task CreateTask(CreateTodoTaskDto createTodoTaskDto)
        {
            await _applicationDbContext.TodoItems.AddAsync(
                new Domain.Entities.TodoItems {
                    Name = createTodoTaskDto.Name,
                    IsComplete = createTodoTaskDto.IsComplete
                });


                 
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TodoItemResponse>> GetAllTaskTodo()
        {
            var items = await _applicationDbContext.TodoItems.ToListAsync();
            return items.Select(x => new TodoItemResponse
            {
                Id = x.Id,
                Name = x.Name,
                IsComplete = x.IsComplete,
            });
        } 
    }
}
