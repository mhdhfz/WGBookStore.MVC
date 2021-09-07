using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGBookStore.MVC.Models
{
    public class SignInUserModel
    {
		[Required(ErrorMessage = "Please enter your email")]
		[EmailAddress(ErrorMessage = "Please enter a valid email")]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Remember me")]
		public bool RememberMe { get; set; }

	}
}
