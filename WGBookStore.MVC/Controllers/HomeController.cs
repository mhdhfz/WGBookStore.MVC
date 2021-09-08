using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGBookStore.MVC.Interfaces;
using WGBookStore.MVC.Models;

namespace WGBookStore.MVC.Controllers
{
    public class HomeController : Controller
    {
		private readonly IUserService _userService;
		private readonly IEmailService _emailService;

		public HomeController(IUserService userService,
			IEmailService emailService)
		{
			_userService = userService;
			_emailService = emailService;
		}
        public ViewResult Index()
		{
			//var userEmailOption = new UserEmailOptionModel
			//{
			//	ToEmails = new List<string> { "test@gmail.com" },
			//	PlaceHolders = new List<KeyValuePair<string, string>>()
			//	{
			//		new KeyValuePair<string, string>("{{UserName}}", "hafiz")
			//	}
				
			//};

			//await _emailService.SendTestEmail(userEmailOption);
			//var userId = _userService.GetUserId();
			//var isLoggedIn = _userService.IsAuthenticated();
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
