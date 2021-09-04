﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGBookStore.MVC.Models
{
    public class BookModel
    {
		public int Id { get; set; }

		[Required(ErrorMessage = "Please enter the title of book")]
		[StringLength(200, MinimumLength = 2)]
		public string Title { get; set; }

		[Required(ErrorMessage = "Please enter author name")]
		public string Author { get; set; }

		[StringLength(500, ErrorMessage = "Please enter book description ", MinimumLength = 30)]
		public string Description { get; set; }
		public string Category { get; set; }
		public string Language { get; set; }

		[Required(ErrorMessage = "please enter total pages")]
		[Display(Name = "Total pages of book")]
		public int? TotalPages { get; set; }
	}
}