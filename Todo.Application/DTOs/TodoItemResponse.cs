namespace Todo.Application.DTOs
{
    public record TodoItemResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int IsComplete { get; set; }
    }
}
