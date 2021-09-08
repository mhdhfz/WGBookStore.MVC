using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGBookStore.MVC.Models
{
    public class UserEmailOptionModel
    {
		public List<string> ToEmails { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }

	}
}
