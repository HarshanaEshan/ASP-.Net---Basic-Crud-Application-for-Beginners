using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Student_Registration_Crud_Application.Controllers
{
    public class AdminController : Controller
    {
        // GET: AdminController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdminLogin(string username, string password)
        {
            // Handle login logic here
            if (username == "harshana" && password == "eshan123")
            {
                // Optional: Set a success message (not visible if redirecting immediately)
                ViewBag.SuccessMessage = "Login successful. Redirecting...";

                // Delay for 1 second
                await Task.Delay(1000);

                // Redirect to the admin dashboard or another page on successful login
                // Index <--- function(action) ,  StudentsTables <--- controller name
                return RedirectToAction("Index", "StudentsTables");
            }

            // Return to login view with an error message on failure
            ViewBag.ErrorMessage = "Invalid username or password.";
            return View("Index");
        }

    }
}
