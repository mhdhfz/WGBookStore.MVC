using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGBookStore.MVC.Models;

namespace WGBookStore.MVC.Data
{
    public class BookStoreContext : IdentityDbContext<ApplicationUser>
    {
		public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
		{
		}

		public DbSet<Book> Books { get; set; }
		public DbSet<BookGallery> BookGalleries  { get; set; }
		public DbSet<Language> Languages { get; set; }

	}
}
