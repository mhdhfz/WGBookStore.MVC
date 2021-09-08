using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGBookStore.MVC.Interfaces;
using WGBookStore.MVC.Models;

namespace WGBookStore.MVC.Controllers
{
    public class AccountController : Controller
    {
		private readonly IAccountRepository _accRepo;

		public AccountController(IAccountRepository accRepo)
		{
			_accRepo = accRepo;
		}

		[Route("signup")]
		public IActionResult SignUp()
		{
			return View();
		}
		
		[Route("signup")]
		[HttpPost]
		public async Task<IActionResult> SignUp(SignUpUserModel userModel)
		{
			if (ModelState.IsValid)
			{
				var result = await _accRepo.CreateUserAsync(userModel);

				if (!result.Succeeded)
				{
					foreach (var err in result.Errors)
					{
						ModelState.AddModelError("", err.Description);
					}
					return View();
				}
				ModelState.Clear();
			}
			return View();
		}

		[Route("login")]
		public IActionResult SignIn()
		{
			return View();
		}

		[Route("login")]
		[HttpPost]
		public async Task<IActionResult> SignIn(SignInUserModel signInUser, string returnUrl)
		{
			if (ModelState.IsValid)
			{
				var result = await _accRepo.UserSignInAsync(signInUser);
				if (result.Succeeded)
				{
					if (!string.IsNullOrEmpty(returnUrl))
					{
						return LocalRedirect(returnUrl);
					}
					return RedirectToAction("Index", "Home");
				}

				ModelState.AddModelError("", "Invalid Credentials");
			}
			return View(signInUser);
		}

		[Route("logout")]
		public async Task<IActionResult> Logout()
		{
			await _accRepo.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
		
		public IActionResult ChangePassword()
		{
			return View();
		}
		
		[HttpPost]
		public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
		{
			if (ModelState.IsValid)
			{
				var result = await _accRepo.ChangePasswordAsync(model);
				if (result.Succeeded)
				{
					ViewBag.IsSuccess = true;
					ModelState.Clear();
					return View();
				}

				foreach (var err in result.Errors)
				{
					ModelState.AddModelError("", err.Description);
				}
			}

			return View(model);
		}
	}
}
