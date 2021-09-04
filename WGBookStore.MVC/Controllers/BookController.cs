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

		public BookController(IBookRepository bookRepo)
		{
			_bookRepo = bookRepo;
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

		public ViewResult AddNewBook(bool isSuccess = false, int bookId = 0)
		{
			//ViewBag.Language = GetLanguages().Select(x => new SelectListItem()
			//{
			//	Text = x.Name,
			//	Value = x.Id.ToString()
			//}).ToList();

			//ViewBag.Language = new List<SelectListItem>()
			//{
			//	new SelectListItem() {Text = "Melayu", Value = "1", Selected = true},
			//	new SelectListItem() {Text = "English", Value = "2"},
			//	new SelectListItem() {Text = "Mandarin", Value = "3"},
			//	new SelectListItem() {Text = "Tamil", Value = "4"},
			//};

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
			//ViewBag.Language = new SelectList(new List<string>() { "Melayu", "English", "Spanish" });
			//ViewBag.Language = new SelectList(GetLanguages(), "Id", "Name");

			//ViewBag.Language = new List<SelectListItem>()
			//{
			//	new SelectListItem() {Text = "Melayu", Value = "1", Selected = true},
			//	new SelectListItem() {Text = "English", Value = "2"},
			//	new SelectListItem() {Text = "Mandarin", Value = "3"},
			//	new SelectListItem() {Text = "Tamil", Value = "4"},
			//};

			return View();
		}

		private List<LanguageModel> GetLanguages()
		{
			return new List<LanguageModel>()
			{
				new LanguageModel() {Id = 1, Name = "Melayu"},
				new LanguageModel() {Id = 2, Name = "English"},
				new LanguageModel() {Id = 3, Name = "Spanish"}
			};
		}
    }
}
