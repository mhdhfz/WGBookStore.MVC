using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGBookStore.MVC.Models
{
    public class ChangePasswordModel
    {
		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Current Password")]
		public string CurrentPassword { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "New Password")]
		public string NewPassword { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Confirm New Password")]
		[Compare("NewPassword", ErrorMessage = "Confirm new password does no match")]
		public string ConfirmNewPassword { get; set; }

	}
}
