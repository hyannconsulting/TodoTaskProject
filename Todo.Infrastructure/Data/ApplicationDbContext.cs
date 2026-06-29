using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Todo.Domain.Entities;

namespace Todo.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
           
            
        }

        public DbSet<TodoItems> TodoItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
                      


           SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItems>().HasData(
                new TodoItems { Id = 1, Name = "Jean", IsComplete = 0 },
                new TodoItems { Id = 2, Name = "Jean", IsComplete = 0 },
                new TodoItems { Id = 3, Name = "Jean", IsComplete = 0 }
                );
        }
    }
}
