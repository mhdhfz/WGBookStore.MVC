using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGBookStore.MVC.Data;
using WGBookStore.MVC.Interfaces;
using WGBookStore.MVC.Models;

namespace WGBookStore.MVC.Repositories
{
	public class BookRepository : IBookRepository
	{
		private readonly BookStoreContext _context;

		public BookRepository(BookStoreContext context)
		{
			_context = context;
		}

		public async Task<List<BookModel>> GetAllBooks()
		{
			return await _context.Books
			  .Select(book => new BookModel()
			  {
				  Author = book.Author,
				  Category = book.Category,
				  Description = book.Description,
				  Id = book.Id,
				  LanguageId = book.LanguageId,
				  Language = book.Language.Name,
				  Title = book.Title,
				  TotalPages = book.TotalPages,
				  CoverPhotoPath = book.CoverPhotoUrl
			  }).ToListAsync();
		}

		public async Task<List<BookModel>> GetTopBooks(int count)
		{
			return await _context.Books
			  .Select(book => new BookModel()
			  {
				  Author = book.Author,
				  Category = book.Category,
				  Description = book.Description,
				  Id = book.Id,
				  LanguageId = book.LanguageId,
				  Language = book.Language.Name,
				  Title = book.Title,
				  TotalPages = book.TotalPages,
				  CoverPhotoPath = book.CoverPhotoUrl
			  }).Take(count).ToListAsync();
		}

		public async Task<BookModel> GetBookById(int id)
		{
			return await _context.Books.Where(x => x.Id == id)
				 .Select(book => new BookModel()
				 {
					 Author = book.Author,
					 Category = book.Category,
					 Description = book.Description,
					 Id = book.Id,
					 LanguageId = book.LanguageId,
					 Language = book.Language.Name,
					 Title = book.Title,
					 TotalPages = book.TotalPages,
					 CoverPhotoPath = book.CoverPhotoUrl,
					 Galleries = book.BookGalleries.Select(g => new GalleryModel() 
					 {
						Id = g.Id,
						Name = g.Name,
						URL = g.URL
					 }).ToList(),
					 BookPdfPath = book.BookPdfUrl
				 }).FirstOrDefaultAsync();

		}

		public List<BookModel> SearchBook(string title, string authorName)
		{
			return null;
		}

		public async Task<Book> AddNewBook(BookModel model)
		{
			var newBook = new Book()
			{
				Author = model.Author,
				CreatedOn = DateTime.UtcNow,
				Description = model.Description,
				Title = model.Title,
				LanguageId = model.LanguageId,
				TotalPages = model.TotalPages ?? 0,
				UpdatedOn = DateTime.UtcNow,
				CoverPhotoUrl = model.CoverPhotoPath,
				BookPdfUrl = model.BookPdfPath
			};

			newBook.BookGalleries = new List<BookGallery>();

			foreach (var file in model.Galleries)
			{
				newBook.BookGalleries.Add(new BookGallery()
				{
					Name = file.Name,
					URL = file.URL
				});
			}

			await _context.Books.AddAsync(newBook);
			await _context.SaveChangesAsync();
			return newBook;
		}
	}
}
