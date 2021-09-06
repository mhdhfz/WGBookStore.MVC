using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGBookStore.MVC.Interfaces;
using WGBookStore.MVC.Repositories;

namespace WGBookStore.MVC.Components
{
    public class TopBooksViewComponent : ViewComponent
    {
		private readonly IBookRepository _bookRepo;

		public TopBooksViewComponent(IBookRepository bookRepo)
		{
			_bookRepo = bookRepo;
		}

        public async Task<IViewComponentResult> InvokeAsync()
		{
			var topBooks = await _bookRepo.GetTopBooks();
			return View(topBooks);
		}
    }
}
