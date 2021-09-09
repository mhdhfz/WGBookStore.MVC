using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGBookStore.MVC.Data
{
    public class Language
    {
		public int LanguageId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public ICollection<Book> Books { get; set; }

	}
}
