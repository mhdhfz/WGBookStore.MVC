using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGBookStore.MVC.Models;

namespace WGBookStore.MVC.Interfaces
{
    public interface IBookRepository
    {
		List<Book> GetAllBooks();
		Book GetBookById(int id);
		List<Book> SearchBook(string title, string authorName);
    }
}
