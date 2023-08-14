using Microsoft.AspNetCore.Mvc;
using Proyecto2_MVC_AaronVillalobosArguedas.Models;
using System.Diagnostics;

namespace Proyecto2_MVC_AaronVillalobosArguedas.Controllers
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
			bool userIsAuthenticated = User.Identity != null && User.Identity.IsAuthenticated;
			if (userIsAuthenticated)
			{
				return View();
			}
			else
			{
				return Redirect("/Identity/Account/Login");
			}
		}

		public IActionResult Privacy()
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