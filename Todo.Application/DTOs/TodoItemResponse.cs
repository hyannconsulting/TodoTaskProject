namespace Todo.Application.DTOs
{

    public record TodoItemResponse
    {
        public int Id { get; init; }
        public required string Name { get; init; }
        public int IsComplete { get; init; }
    }
}
