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

		public ViewResult GetAllBooks()
		{
			var books = _bookRepo.GetAllBooks();
			return View(books);
		}

		public ViewResult GetBook(int id)
		{
			var book = _bookRepo.GetBookById(id);
			return View(book);
		}

		public List<Book> SearchBooks(string bookName, string authorName)
		{
			return _bookRepo.SearchBook(bookName, authorName);
		}
    }
}
