using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGBookStore.MVC.Data;
using WGBookStore.MVC.Models;

namespace WGBookStore.MVC.Interfaces
{
    public interface IBookRepository
    {
		Task<List<BookModel>> GetAllBooks();
		Task<BookModel> GetBookById(int id);
		List<BookModel> SearchBook(string title, string authorName);
		Task<Book> AddNewBook(BookModel book);
    }
}
