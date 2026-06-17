namespace Todo.Application.DTOs
{
    public record CreateTodoTaskDto
    {
        public required string Name;
        public int IsComplete;
    }
}
