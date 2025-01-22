using Microsoft.AspNetCore.Mvc;

namespace NewWebApp
{
    public class Program
    {
        public string message = "Hello";
        public static void Main(string[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            var app = builder.Build();
            app.UseDefaultFiles(new DefaultFilesOptions
            {
                DefaultFileNames = new List<string> { "Index.html" } // Sets the home page to my index file
            });
            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}" // Builds the app
            );
            app.Run();
        }
        

        private void PassMessage(object sender, System.EventArgs e)
        {
            this.message = "Hello";

        }
    }


    namespace MinimalAspNetApp.Controllers
    {
        // "/Home/ReturnMessage" is the action needed to call a controller subroutine
        public class HomeController : Controller
        {
            [HttpPost]
            public IActionResult Submit(string Username, string Password) // Takes in username and password from the form
            {
                if (Username == null || Password == null) // Input validation
                {
                    return BadRequest("Invalid input"); 
                }
                
                else
                {
                    return Redirect("/Menu.html"); 
                }
            }
            
        }
    }
}
