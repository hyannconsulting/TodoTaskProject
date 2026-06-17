using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Todo.Application.DTOs;

namespace Todo.Application.Interfaces.Services
{
    public interface ITodoServices
    { 

        public Task<IEnumerable<TodoItemResponse>> GetAllItems();
        Task CreateTask(CreateTodoTaskDto createTodoTaskDto);
    }
}
