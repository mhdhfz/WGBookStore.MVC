﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGBookStore.MVC.Data
{
    public class BookStoreContext : DbContext
    {
		public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
		{
		}

		public DbSet<Book> Books { get; set; }
	}
}
