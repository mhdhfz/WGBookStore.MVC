using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
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
		private readonly IWebHostEnvironment _webHstEnv;

		public BookController(IBookRepository bookRepo,
			ILanguageRepository langRepo,
			IWebHostEnvironment webHstEnv)
		{
			_bookRepo = bookRepo;
			_langRepo = langRepo;
			_webHstEnv = webHstEnv;
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
				if (book.CoverPhoto != null)
				{
					string folder = "books/cover/";
					book.CoverPhotoPath = await UploadFile(folder, book.CoverPhoto);
				}
				
				if (book.GalleryFiles != null)
				{
					string folder = "books/gallery/";

					book.Galleries = new List<GalleryModel>();

					foreach (var file in book.GalleryFiles)
					{
						var gallery = new GalleryModel()
						{
							Name = file.FileName,
							URL = await UploadFile(folder, file)
						};
						book.Galleries.Add(gallery);
					}
				}

				if (book.BookPdf != null)
				{
					string folder = "books/pdf/";
					book.BookPdfPath = await UploadFile(folder, book.BookPdf);
				}

				var newBook = await _bookRepo.AddNewBook(book);
				return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = newBook.Id});

			}
			ViewBag.Language = new SelectList(await _langRepo.GetAllLanguages(), "LanguageId", "Name");

			return View();
		}

		private async Task<string> UploadFile(string folderPath, IFormFile file)
		{
			
			folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

			string serverFolder = Path.Combine(_webHstEnv.WebRootPath, folderPath);

			await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

			return "/" + folderPath;
		}
	}
}
