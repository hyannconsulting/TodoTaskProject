using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Domain.Entities
{
    public class TodoItems
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int IsComplete { get; set; }
    }
}
