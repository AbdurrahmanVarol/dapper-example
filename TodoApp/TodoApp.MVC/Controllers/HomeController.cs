using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using TodoApp.Business.Services;
using TodoApp.MVC.Models;

namespace TodoApp.MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ITodoService _todoService;
        private int UserId => int.Parse(User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
        private string FullName => User.Claims.First(x => x.Type == "FullName").Value;

        public HomeController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.FullName = FullName;
            var todos = await _todoService.GetTodosByUserId(UserId);
            return View(todos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}