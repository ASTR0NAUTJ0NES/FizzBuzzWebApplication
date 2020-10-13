using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FizzBuzzWebApplication.Models;
using System.Text;
using Microsoft.Extensions.Primitives;

namespace FizzBuzzWebApplication.Controllers
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
            return View();
        }

        [HttpGet]
        public IActionResult Solve()
        {
            return View();
        } 

        [HttpPost]
        public IActionResult Solve(string fizz, string buzz)
        {
            var multiple1 = Convert.ToInt32(fizz);
            var multiple2 = Convert.ToInt32(buzz);

            var output = new StringBuilder();

            for (var loop = 0; loop <= 100; loop++)
            {
                if ((loop % multiple1 == 0) && (loop % multiple2 == 0))
                    output.AppendLine($"{loop} FizzBuzz");
                else if (loop % multiple1 == 0)
                    output.AppendLine($"{loop} Fizz");
                else if (loop % multiple2 == 0)
                    output.AppendLine($"{loop} Buzz");
                else
                    output.AppendLine($"{loop}");
                output.AppendLine("<br>");
            }

            ViewData["Output"] = output.ToString();

            return View();
        }

        public IActionResult Code()
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
