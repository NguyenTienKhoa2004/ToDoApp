using Entities;

namespace UseCases
{
    // Lớp dịch vụ quản lý danh sách ToDo
    public class ToDoListManager
    {
        private readonly IToDoItemRepository _repository;

        // Constructor chuẩn để DI
        public ToDoListManager(IToDoItemRepository repository)
        {
            _repository = repository;
        }

        // Lấy toàn bộ todo items của một user
        public async Task<IEnumerable<ToDoItem>> GetTodoItemsAsync(string userId)
        {
            return await _repository.GetTodoItemsAsync(userId);
        }

        // Thêm mới một item cho user
        public async Task AddTodoItemAsync(ToDoItem item, string userId)
        {
            await _repository.AddAsync(item, userId);
        }

        // Đánh dấu hoàn thành
        public async Task MarkCompleteAsync(int id, string userId)
        {
            var item = await _repository.GetByIdAsync(id, userId);
            if (item != null)
            {
                item.IsCompleted = true;
                await _repository.UpdateAsync(item, userId);
            }
        }

        // Xóa item
        public async Task DeleteAsync(int id, string userId)
        {
            await _repository.DeleteAsync(id, userId);
        }
    }
}
