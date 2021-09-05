using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGBookStore.MVC.Data;
using WGBookStore.MVC.Interfaces;
using WGBookStore.MVC.Models;

namespace WGBookStore.MVC.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
		private readonly BookStoreContext _context;

		public LanguageRepository(BookStoreContext context)
		{
			_context = context;
		}

		public async Task<List<LanguageModel>> GetAllLanguages()
		{
			var languages = await _context.Languages.Select(l => new LanguageModel()
			{
				LanguageId = l.LanguageId,
				Description = l.Description,
				Name = l.Name
			}).ToListAsync();

			return languages;
		}
	}
}
