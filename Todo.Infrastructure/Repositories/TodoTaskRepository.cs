using Microsoft.EntityFrameworkCore;
using Todo.Application.DTOs;
using Todo.Application.Interfaces.Repositories;
using Todo.Domain.Entities;
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

        public async Task<GetTodoTaskDto?> GetTaskById(int id)
        {

            var item= await _applicationDbContext.FindAsync<TodoItems>(id);
            if (item == null) return null;

            return new GetTodoTaskDto { Id = item.Id,Name = item.Name, IsComplete = item.IsComplete};
        }

        public async Task<bool> UpdateTaskById(int id , UpdateTodoDto taskdto)
        {

            var item = await _applicationDbContext.FindAsync<TodoItems>(id);
            if (item == null) return false;


            item.IsComplete = taskdto.IsComplete;
            item.Name = taskdto.Name;

            await _applicationDbContext.SaveChangesAsync();

            return true;
        }

     public  async Task<bool>  DeleteTask(int id)
        {
            var item = await _applicationDbContext.FindAsync<TodoItems>(id);
            if (item == null) return false;

           
            _applicationDbContext.Remove(item);
            await _applicationDbContext.SaveChangesAsync();

            return true;
        }
    }
}
