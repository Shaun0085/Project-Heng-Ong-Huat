using System;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using System.Data.SqlClient;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    public class DiscussionController : Controller
    {
        public DiscussionController(Project_DbContext database)
        {
            data = database;
        }

        private readonly Project_DbContext data;

        [HttpPost]
        public async Task<IActionResult> Authorize_review([Bind("Review")] WebApplication1.Models.Discussion userModel)
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
                TempData["Message"] = "Successfully Added!";
                return RedirectToAction("Discussion", "Home");
            }
            return RedirectToAction("Discussion", "Home");
        }
    }
}
