﻿using Microsoft.AspNetCore.Mvc;
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
        public string Index()
		{
			return "WGBookStore";
		}
    }
}