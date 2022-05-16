using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class SignUpController : Controller
    {
        public SignUpController(Project_DbContext database)
        {
            data = database;
            
        }

        private readonly Project_DbContext data;
        

        [HttpPost]
        public async Task<IActionResult> Authorize_signup([Bind("FirstName,LastName,Email,Password")] WebApplication1.Models.User userModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    data.Add(userModel);
                    await data.SaveChangesAsync();
                }
                catch
                {
                    throw;
                }
                TempData["success_message"] = "Successfully Registered!";
                return RedirectToAction("SignIn", "Home");
            }
            return RedirectToAction("SignUp", "Home");
        }
    }
}
