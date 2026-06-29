using Todo.Application.DTOs;
using Todo.Application.Interfaces.Repositories;
using Todo.Application.Interfaces.Services;

namespace Todo.Infrastructure.Services
{
    public  class TodoServices(ITodoTaskRepository todoTaskRepository) : ITodoServices
    {
        private readonly ITodoTaskRepository _todoTaskRepository = todoTaskRepository ?? throw new ArgumentNullException(nameof(todoTaskRepository));

        public async Task<IEnumerable<TodoItemResponse>> GetAllItems()
        {
           return await _todoTaskRepository.GetAllTaskTodo();
        }

        public async Task CreateTask(CreateTodoTaskDto createTodoTaskDto)
        {
            await _todoTaskRepository.CreateTask(createTodoTaskDto);
        }

        public async Task<GetTodoTaskDto?> GetTaskById(int id)
        {
          return await _todoTaskRepository.GetTaskById(id);
        
        }

        public async Task<bool> UpdateTaskById(int id, UpdateTodoDto taskdto)
        {
            return await _todoTaskRepository.UpdateTaskById(id, taskdto);
        }

        public async Task<bool> DeleteTask(int id)
        {
            return await _todoTaskRepository.DeleteTask(id);
        }
     
    }
}
