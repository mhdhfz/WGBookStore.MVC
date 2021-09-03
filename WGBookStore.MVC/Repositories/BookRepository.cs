using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGBookStore.MVC.Interfaces;
using WGBookStore.MVC.Models;

namespace WGBookStore.MVC.Repositories
{
	public class BookRepository : IBookRepository
	{
		public List<Book> GetAllBooks()
		{
			return DataSource();
		}

		public Book GetBookById(int id)
		{
			return DataSource().Where(b => b.Id == id).FirstOrDefault();
		}

		public List<Book> SearchBook(string title, string authorName)
		{
			return DataSource().Where(t => t.Title.Contains(title) || t.Author.Contains(authorName)).ToList();
		}

		private static List<Book> DataSource()
		{
			return new List<Book>()
			{
				new Book() 
				{
					Id = 1,
					Title="MVC",
					Author = "Hafez",
					Description = "Book about MVC",
					Category = "Framework",
					TotalPages = 607,
					Language = "English"
				},
				new Book() 
				{
					Id = 2,
					Title="Razor Pages",
					Author = "Malek",
					Description = "Book about Razor Pages",
					Category = "User Interface",
					TotalPages = 300,
					Language = "English"
				},
				new Book() 
				{
					Id = 3,
					Title="Web API",
					Author = "Kamil",
					Description = "Book about Web API",
					Category = "API",
					TotalPages = 509,
					Language = "Spanish"
				},
				new Book() 
				{
					Id = 4,
					Title="Xamarin",
					Author = "Nana",
					Description = "Book about Xamarin",
					Category = "Mobile",
					TotalPages = 491,
					Language = "Melayu"
				},
				new Book() 
				{
					Id = 5,
					Title="Azure",
					Author = "Intan",
					Description = "Book about Azure",
					Category = "Cloud",
					TotalPages = 982,
					Language = "Hindi"
				},
				new Book() 
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
	}
}
