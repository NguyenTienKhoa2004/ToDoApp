using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ToDoList.Data
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
            : base(options)
        {
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}