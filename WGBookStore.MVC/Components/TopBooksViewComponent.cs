using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGBookStore.MVC.Components
{
    public class TopBooksViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
    }
}
