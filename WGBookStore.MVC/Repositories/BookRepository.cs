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
			var allBooks = new List<BookModel>();
			var books = await _context.Books.ToListAsync();
			if (books?.Any() == true)
			{
				foreach (var book in books)
				{
					allBooks.Add(new BookModel()
					{
						Author = book.Author,
						Category = book.Category,
						Description = book.Description,
						Id = book.Id,
						Language = book.Language,
						Title = book.Title,
						TotalPages = book.TotalPages
					});
				}
			}
			return allBooks;
		}

		public async Task<BookModel> GetBookById(int id)
		{
			var book = await _context.Books.FindAsync(id);
			if (book != null)
			{
				var bookDetails = new BookModel()
				{
					Author = book.Author,
					Category = book.Category,
					Description = book.Description,
					Id = book.Id,
					Language = book.Language,
					Title = book.Title,
					TotalPages = book.TotalPages
				};

				return bookDetails;
			}

			return null;
		}

		public List<BookModel> SearchBook(string title, string authorName)
		{
			return DataSource().Where(t => t.Title.Contains(title) || t.Author.Contains(authorName)).ToList();
		}

		private static List<BookModel> DataSource()
		{
			return new List<BookModel>()
			{
				new BookModel() 
				{
					Id = 1,
					Title="MVC",
					Author = "Hafez",
					Description = "Book about MVC",
					Category = "Framework",
					TotalPages = 607,
					Language = "English"
				},
				new BookModel() 
				{
					Id = 2,
					Title="Razor Pages",
					Author = "Malek",
					Description = "Book about Razor Pages",
					Category = "User Interface",
					TotalPages = 300,
					Language = "English"
				},
				new BookModel() 
				{
					Id = 3,
					Title="Web API",
					Author = "Kamil",
					Description = "Book about Web API",
					Category = "API",
					TotalPages = 509,
					Language = "Spanish"
				},
				new BookModel() 
				{
					Id = 4,
					Title="Xamarin",
					Author = "Nana",
					Description = "Book about Xamarin",
					Category = "Mobile",
					TotalPages = 491,
					Language = "Melayu"
				},
				new BookModel() 
				{
					Id = 5,
					Title="Azure",
					Author = "Intan",
					Description = "Book about Azure",
					Category = "Cloud",
					TotalPages = 982,
					Language = "Hindi"
				},
				new BookModel() 
				{
					Id = 5,
					Title="IoT",
					Author = "Zakwan",
					Description = "Book about IoT",
					Category = "Internet of Things",
					TotalPages = 1200,
					Language = "English"
				}
			};
		}

		public async Task<Book> AddNewBook(BookModel model)
		{
			var newBook = new Book()
			{
				Author = model.Author,
				CreatedOn = DateTime.UtcNow,
				Description = model.Description,
				Title = model.Title,
				TotalPages = model.TotalPages,
				UpdatedOn = DateTime.UtcNow
			};

			await _context.Books.AddAsync(newBook);
			await _context.SaveChangesAsync();
			return newBook;
		}
	}
}
