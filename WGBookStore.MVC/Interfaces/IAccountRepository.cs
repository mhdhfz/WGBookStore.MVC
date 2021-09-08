using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGBookStore.MVC.Models;

namespace WGBookStore.MVC.Interfaces
{
	public interface IAccountRepository
	{
		Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);
		Task<SignInResult> UserSignInAsync(SignInUserModel signInUser);
		Task SignOutAsync();
		Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model);
	}
}
