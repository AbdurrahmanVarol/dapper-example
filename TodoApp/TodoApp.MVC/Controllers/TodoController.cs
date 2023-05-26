using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TodoApp.Business.Dtos.Requests;
using TodoApp.Business.Services;

namespace TodoApp.MVC.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;
        private int UserId => int.Parse(User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            var todos = await _todoService.GetTodosByUserId(UserId);
            HttpContext.Session.SetString("CurrentState", "All");
            return Json(todos);
        }
        [HttpGet]
        public async Task<IActionResult> GetActiveTodos()
        {
            var todos = await _todoService.GetActiveTodosByUserId(UserId);
            HttpContext.Session.SetString("CurrentState", "Active");
            return Json(todos);
        }
        [HttpGet]
        public async Task<IActionResult> GetCompletedTodos()
        {
            var todos = await _todoService.GetCompletedTodosByUserId(UserId);
            HttpContext.Session.SetString("CurrentState", "Completed");
            return Json(todos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] CreateTodoRequest createTodoRequest)
        {
            await _todoService.CreateAsync(createTodoRequest);
            HttpContext.Session.SetString("CurrentState", "All");
            return Ok(true);
        } 
        [HttpPost]
        public async Task<IActionResult> ToggleComplete([FromBody] ToggleCompleteTodoRequest request)
        {
            await _todoService.ToggleCompleteAsync(request);
            return Ok(true);
        }
        [HttpPost]
        public async Task<IActionResult> DeteleTodo([FromBody] DeleteTodoRequest request)
        {
            await _todoService.DeleteAsync(request);
            var currentState = HttpContext.Session.GetString("CurrentState")??"All";
            return Ok(new
            {
                CurrentState = currentState,
            });
        }
        [HttpPost]
        public async Task<IActionResult> DeteleAllTodos()
        {
            await _todoService.DeleteAllByUserId(UserId);
            var currentState = HttpContext.Session.GetString("CurrentState")??"All";
            return Ok(new
            {
                CurrentState = currentState,
            });
        }

    }
}
