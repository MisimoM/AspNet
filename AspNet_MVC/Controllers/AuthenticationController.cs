using Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;

namespace Presentation.Controllers
{
    public class AuthenticationController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager) : Controller
    {
        private readonly UserManager<UserEntity> _userManager = userManager;
        private readonly SignInManager<UserEntity> _signInManager = signInManager;

        [HttpGet]
		[Route("/SignUp")]
		public IActionResult SignUp() => View(new SignUpViewModel());

		[HttpPost]
        [Route("/SignUp")]
        public async Task<IActionResult> SignUp(SignUpViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
                var exists = await _userManager.Users.AnyAsync(x => x.Email == viewModel.Form.Email);
                if (exists)
                {
                    ModelState.AddModelError("AlreadyExists", "Error");
                    return View(viewModel);
                }

                var userEntity = new UserEntity
                {
                    FirstName = viewModel.Form.FirstName,
                    LastName = viewModel.Form.LastName,
                    Email = viewModel.Form.Email,
                    UserName = viewModel.Form.Email
                };

                var result = await _userManager.CreateAsync(userEntity, viewModel.Form.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn");
                }
            }

            return View(viewModel);
		}

        [HttpGet]
        [Route("/SignIn")]
        public IActionResult SignIn()
        {
            return View(new SignInViewModel());
        }

        [HttpPost]
        [Route("/SignIn")]
        public async Task<IActionResult> SignIn(SignInViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(viewModel.Form.Email, viewModel.Form.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Account", "Account");
                }
            }

            viewModel.ErrorMessage = "\u26A0 Incorrect email or password";
            return View(viewModel);
        }

        [HttpGet]
        [Route("/SignOut")]
        public new async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
