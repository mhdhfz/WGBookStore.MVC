using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGBookStore.MVC.Interfaces;

namespace WGBookStore.MVC.Controllers
{
    public class HomeController : Controller
    {
		private readonly IUserService _userService;

		public HomeController(IUserService userService)
		{
			_userService = userService;
		}
        public ViewResult Index()
		{
			var userId = _userService.GetUserId();
			var isLoggedIn = _userService.IsAuthenticated();
			return View();
		}

		public IActionResult About()
		{
			return View();
		}

		public ViewResult Contact()
		{
			return View();
		}

    }
}
