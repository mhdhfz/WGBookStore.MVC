using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGBookStore.MVC.Models
{
    public class SignUpUserModel
    {
		[Required(ErrorMessage = "Please enter your email")]
		[EmailAddress(ErrorMessage = "Please enter a valid email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Please enter a strong password")]
		[Compare("ConfirmPassword", ErrorMessage = "Pasword does not match")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "Please confirm your password")]
		[Display(Name = "Confrim Password")]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }

	}
}
