using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
		private readonly ILanguageRepository _langRepo;

		public BookController(IBookRepository bookRepo, ILanguageRepository langRepo)
		{
			_bookRepo = bookRepo;
			_langRepo = langRepo;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		public async Task<ViewResult> GetAllBooks()
		{
			var books = await _bookRepo.GetAllBooks();
			return View(books);
		}

		public async Task<ViewResult> GetBook(int id, string bookName)
		{
			var book = await _bookRepo.GetBookById(id);
			return View(book);
		}

		public List<BookModel> SearchBooks(string bookName, string authorName)
		{
			return _bookRepo.SearchBook(bookName, authorName);
		}

		public async Task<ViewResult> AddNewBook(bool isSuccess = false, int bookId = 0)
		{

			ViewBag.Language = new SelectList(await _langRepo.GetAllLanguages(), "LanguageId", "Name");

			ViewBag.IsSuccess = isSuccess;
			ViewBag.BookId = bookId;
			return View();
		}
		
		[HttpPost]
		public async Task<IActionResult> AddNewBook(BookModel book)
		{
			if (ModelState.IsValid)
			{
				var newBook = await _bookRepo.AddNewBook(book);
				return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = newBook.Id});

			}
			ViewBag.Language = new SelectList(await _langRepo.GetAllLanguages(), "LanguageId", "Name");

			return View();
		}
    }
}
