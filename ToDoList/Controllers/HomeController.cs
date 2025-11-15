using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoList.Models;
using UseCases;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ToDoListManager _listManager;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(
            ToDoListManager listManager,
            ILogger<HomeController> logger,
            UserManager<IdentityUser> userManager)
        {
            _listManager = listManager;
            _logger = logger;
            _userManager = userManager;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);

            var todoItems = await _listManager.GetTodoItemsAsync(userId);

            return View(new ToDoListViewModel
            {
                Items = todoItems.Select(ti => new Item
                {
                    Id = ti.Id,
                    Text = ti.Text,
                    IsCompleted = ti.IsCompleted
                })
            });
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(Item item)
        {
            var userId = _userManager.GetUserId(User);

            await _listManager.AddTodoItemAsync(new ToDoItem
            {
                Text = item.Text,
                IsCompleted = false
            }, userId);

            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            var userId = _userManager.GetUserId(User);
            await _listManager.MarkCompleteAsync(id, userId);
            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = _userManager.GetUserId(User);
            await _listManager.DeleteAsync(id, userId);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
