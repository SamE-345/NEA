using Microsoft.AspNetCore.Mvc;

namespace NewWebApp
{
    public class Program
    {
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
    }
    

    namespace MinimalAspNetApp.Controllers
        {
            public class HomeController : Controller
            {
                [HttpPost]
                public IActionResult Submit(string textbox1) // Responds to post from form and returns. 
                {
                    // Retrieve the value entered in the form
                    string inputText = textbox1;

                    // Log or process the input text
                    Console.WriteLine("Retrieved Text: " + inputText);
                    return Content(""); //Choose text to return. Need to work out whether I can return a webpage.
                }
            }
        }

}
