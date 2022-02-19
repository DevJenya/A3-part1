using Microsoft.AspNetCore.Mvc;
using part1.Models;
using System.Diagnostics;


namespace part1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();

            //

            if (Request.Cookies["cook"] == null)
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Append("cook", "2");

                this.ViewData["visits_times"] = Request.Cookies["cook"];
            } 
            else
            {
                
                var cook = Int32.Parse(Request.Cookies["cook"]);
                cook++;

                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Append("cook", cook.ToString());


                this.ViewData["visits_times"] = Request.Cookies["cook"];
                this.ViewData["ip_addr"] = remoteIpAddress;

            }


            

            return View();
        }

     

    }
}