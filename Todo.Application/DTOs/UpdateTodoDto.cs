using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Todo.Application.DTOs
{
    public record UpdateTodoDto
    {
        [JsonPropertyName("name")]
        public required string Name { get; init; }

        [JsonPropertyName("isComplete")]
        public int IsComplete { get; init; }
    }
}
