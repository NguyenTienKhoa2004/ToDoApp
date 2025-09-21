using Entities;
using Microsoft.AspNetCore.Http;    
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public async Task AddAsync(ToDoItem item, string userId)
        {
            item.UserId = userId;
            await _context.ToDoItems.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ToDoItem>> GetTodoItemsAsync(string userId)
        {
            return await _context.ToDoItems
                .Where(i => i.UserId == userId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ToDoItem?> GetByIdAsync(int id, string userId)
        {
            return await _context.ToDoItems
                .FirstOrDefaultAsync(i => i.Id == id && i.UserId == userId);
        }

        public async Task UpdateAsync(ToDoItem item, string userId)
        {
            var existing = await _context.ToDoItems.FirstOrDefaultAsync(i => i.Id == item.Id && i.UserId == userId);
            if (existing == null) return;
            existing.Text = item.Text;
            existing.IsCompleted = item.IsCompleted;
            existing.Priority = item.Priority;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id, string userId)
        {
            var item = await _context.ToDoItems.FirstOrDefaultAsync(i => i.Id == id && i.UserId == userId);
            if (item == null) return;
            _context.ToDoItems.Remove(item);
            await _context.SaveChangesAsync();
        }
    }

}
