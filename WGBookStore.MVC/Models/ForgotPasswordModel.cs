using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGBookStore.MVC.Models
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Registered email address")]
        public string Email { get; set; }
        public bool IsEmailSent { get; set; }

    }
}
