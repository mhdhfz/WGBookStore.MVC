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
				new Book() {Id = 1, Title="MVC", Author = "Hafez"},
				new Book() {Id = 2, Title="Razor Pages", Author = "Malek"},
				new Book() {Id = 3, Title="Web API", Author = "Kamil"},
				new Book() {Id = 4, Title="Xamarin", Author = "Nana"},
				new Book() {Id = 5, Title="Azure", Author = "Zakwan"}
			};
		}
	}
}
