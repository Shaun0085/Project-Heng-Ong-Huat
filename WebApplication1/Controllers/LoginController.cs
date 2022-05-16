using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        public LoginController(Project_DbContext database)
        {
            data = database;
        }

        private Project_DbContext data;

        [HttpPost]
        public ActionResult Authorize_login(WebApplication1.Models.User userModel)
        {
            var userDetails = data.User.Where(x => x.Email == userModel.Email && x.Password == userModel.Password).FirstOrDefault();
                
            if (userDetails == null)
            {
            TempData["incorrect_details"] = "Wrong User Email or Password!";
            return RedirectToAction("SignIn", "Home");
            }
            else
            {
                return RedirectToAction("Home", "Home");
            }
        }
    }
}
