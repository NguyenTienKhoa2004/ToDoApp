using UseCases;
using Entities;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure
{
    public class InMemoryToDoItemRepository : IToDoItemRepository
    {
        private readonly List<ToDoItem> _items;

        public InMemoryToDoItemRepository()
        {
            _items = [];
        }

        public void Add(ToDoItem item)
        {
            // Ensure unique Id if not set
            if (item.Id == 0)
            {
                item.Id = _items.Count > 0 ? _items.Max(x => x.Id) + 1 : 1;
            }
            _items.Add(item);
        }

        public void Delete(int id)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _items.Remove(item);
            }
        }

        public ToDoItem? GetById(int id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ToDoItem> getTodoItems()
        {
            return _items;
        }

        public void Update(ToDoItem item)
        {
            var existing = _items.FirstOrDefault(x => x.Id == item.Id);
            if (existing != null)
            {
                existing.Text = item.Text;
                existing.IsCompleted = item.IsCompleted;
            }
        }
    }
}
