using Microsoft.AspNetCore.Mvc;
using Proyecto2_MVC_AaronVillalobosArguedas.Data;
using Proyecto2_MVC_AaronVillalobosArguedas.Models;
using System.Diagnostics;

namespace Proyecto2_MVC_AaronVillalobosArguedas.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDbContext _context;

		public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
		{
			_logger = logger;
			_context = context;
		}

		public IActionResult Index()
		{
			bool userIsAuthenticated = User.Identity != null && User.Identity.IsAuthenticated;
			if (userIsAuthenticated)
			{
				List<Producto> products = _context.Productos.Where(product => product.CantidadActual <= product.CantidadMinima).ToList();
				return View(products);
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