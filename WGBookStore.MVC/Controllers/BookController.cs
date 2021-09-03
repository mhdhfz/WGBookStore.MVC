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
    public class BookController : Controller
    {
		private readonly IBookRepository _bookRepo;

		public BookController(IBookRepository bookRepo)
		{
			_bookRepo = bookRepo;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		public List<Book> GetAllBooks()
		{
			return _bookRepo.GetAllBooks();
		}

		public Book GetBook(int id)
		{
			return _bookRepo.GetBookById(id);
		}

		public List<Book> SearchBooks(string bookName, string authorName)
		{
			return _bookRepo.SearchBook(bookName, authorName);
		}
    }
}
