using Todo.Application.DTOs;
using Todo.Application.Interfaces.Repositories;
using Todo.Application.Interfaces.Services;

namespace Todo.Infrastructure.Services
{
    public  class TodoServices(ITodoTaskRepository todoTaskRepository) : ITodoServices
    {
        private readonly ITodoTaskRepository todoTaskRepository = todoTaskRepository ?? throw new ArgumentNullException(nameof(todoTaskRepository));

        public async Task<TodoItemResponse> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public async Task CreateTask(CreateTodoTaskDto createTodoTaskDto)
        {
            await todoTaskRepository.CreateTask(createTodoTaskDto);
        }
        

        public async Task DeleteItems()
        {
        }
    }
}
