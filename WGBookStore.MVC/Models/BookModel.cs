using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGBookStore.MVC.Enums;

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

		[StringLength(500, ErrorMessage = "Please enter book description ")]
		public string Description { get; set; }
		public string Category { get; set; }

		[Required(ErrorMessage = "Please choose the language of book")]
		[Display(Name = "Language")]
		public int LanguageId { get; set; }

		public string Language { get; set; }

		[Required(ErrorMessage = "please enter total pages")]
		[Display(Name = "Total pages of book")]
		public int? TotalPages { get; set; }

		[Display(Name = "Choose the cover photo of your book")]
		[Required]
		public IFormFile CoverPhoto { get; set; }
		public string CoverPhotoPath { get; set; }

		[Display(Name = "Choose the gallery images of your book")]
		[Required]
		public IFormFileCollection GalleryFiles { get; set; }
		public List<GalleryModel> Galleries { get; set; }
	}
}
