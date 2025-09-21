using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases
{
    public interface IToDoItemRepository
    {
        
        //void Add(ToDoItem item);
        //void Delete(int id);
        //ToDoItem? GetById(int id);
        //IEnumerable<ToDoItem> getTodoItems();
        //void Update(ToDoItem item);


        Task AddAsync(ToDoItem item, string userId);
        Task<IEnumerable<ToDoItem>> GetTodoItemsAsync(string userId);
        Task<ToDoItem?> GetByIdAsync(int id, string userId);
        Task UpdateAsync(ToDoItem item, string userId);
        Task DeleteAsync(int id, string userId);
    }
}
