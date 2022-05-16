using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        Project_DbContext _database;
        public UserController(Project_DbContext database)
        {
            _database = database;
        }
        public IActionResult Index()
        {
            var users = _database.User.ToList();
            return View(users);
        }
    }
}
