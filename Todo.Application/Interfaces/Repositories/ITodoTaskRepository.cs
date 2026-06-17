using Todo.Application.DTOs;

namespace Todo.Application.Interfaces.Repositories
{
    public interface ITodoTaskRepository
    {
        Task CreateTask(CreateTodoTaskDto createTodoTaskDto);
        Task<bool> DeleteTask(int id);
        Task<IEnumerable<TodoItemResponse>> GetAllTaskTodo();
        Task<GetTodoTaskDto?> GetTaskById(int id);

        Task<bool> UpdateTaskById(int id, UpdateTodoDto taskdto);
    }
}
