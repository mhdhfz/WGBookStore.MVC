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
        public ViewResult Index()
		{
			// view name and object
			//var obj = new { Id = 1, Name = "Hafez" };
			//return View("About", obj);

			// view from another location
			//return View("~/TempView/PageTemp.cshtml");
			//return View("../../TempView/PageTemp");
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
