using Todo.Application.DTOs;

namespace Todo.Application.Interfaces.Repositories
{
    public interface ITodoTaskRepository
    {
        Task CreateTask(CreateTodoTaskDto createTodoTaskDto);
        //Task GetAllTaskTodo();

        Task<IEnumerable<TodoItemResponse>> GetAllTaskTodo();
    }
}
