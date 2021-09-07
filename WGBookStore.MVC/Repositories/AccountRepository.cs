using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGBookStore.MVC.Interfaces;
using WGBookStore.MVC.Models;

namespace WGBookStore.MVC.Repositories
{
	public class AccountRepository : IAccountRepository
	{
		private readonly UserManager<ApplicationUser> _userManager;

		public AccountRepository(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}
		public async Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel)
		{
			var user = new ApplicationUser()
			{
				Email = userModel.Email,
				UserName = userModel.Email
			};

			var result = await _userManager.CreateAsync(user, userModel.Password);
			return result;
		}
	}
}
