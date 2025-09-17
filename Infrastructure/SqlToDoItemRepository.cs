using Entities;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Data;
using UseCases;

namespace Infrastructure
{
    public class SqlToDoItemRepository : IToDoItemRepository
    {
        private readonly ToDoDbContext _context;

        public SqlToDoItemRepository(ToDoDbContext context)
        {
            _context = context;
        }

        public void Add(ToDoItem item)
        {
            _context.ToDoItems.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _context.ToDoItems.Find(id);
            if (item != null)
            {
                _context.ToDoItems.Remove(item);
                _context.SaveChanges();
            }
        }

        public ToDoItem? GetById(int id)
        {
            return _context.ToDoItems.Find(id);
        }

        public IEnumerable<ToDoItem> getTodoItems()
        {
            return _context.ToDoItems.ToList();
        }

        public void Update(ToDoItem item)
        {
            _context.ToDoItems.Update(item);
            _context.SaveChanges();
        }
    }
}