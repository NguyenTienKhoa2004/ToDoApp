using Entities;
namespace UseCases
{
    public class ToDoListManager(IToDoItemRepository repository)
    {
        private readonly IToDoItemRepository repository = repository;

        public IEnumerable<ToDoItem> getTodoItems()
        {
            return repository.getTodoItems();

        }

        public void AddTodoItem(ToDoItem item)
        {
            repository.Add(item);
        }

        public void MarkComplete(int id)
        {
            var item = repository.GetById(id);
            if (item != null)
            {
                item.IsCompleted = true;
                repository.Update(item);

            }
            
        }
        public void Delete(int id)
        {
            repository.Delete(id);
            
            
        }
    }
}
