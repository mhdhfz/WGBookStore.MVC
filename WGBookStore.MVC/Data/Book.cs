﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGBookStore.MVC.Data
{
    public class Book
    {
		public int Id { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public string Description { get; set; }
		public string Category { get; set; }
		public int LanguageId { get; set; }
		public int TotalPages { get; set; }
		public string CoverPhotoUrl { get; set; }
		public DateTime? CreatedOn { get; set; }
		public DateTime? UpdatedOn { get; set; }
		public Language Language { get; set; }
		public ICollection<BookGallery> BookGalleries { get; set; }

	}
}
