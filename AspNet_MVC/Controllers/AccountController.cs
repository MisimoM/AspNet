using Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.Account;

namespace Presentation.Controllers
{
    [Authorize]
    public class AccountController(UserManager<UserEntity> userManager) : Controller
    {
        private readonly UserManager<UserEntity> _userManager = userManager;

        [Route("/Account/Details")]
        public async Task<IActionResult> AccountAsync(AccountViewModel viewModel)
        {
            viewModel = await PopulateAccountInfoAsync();

            return View(viewModel);
        }

        [Route("/Account/{partialViewName}")]
        public async Task<IActionResult> ChangePartialViewAsync(string partialViewName)
        {

            ViewBag.PartialViewName = partialViewName;

            var viewModel = await PopulateAccountInfoAsync();

            return View("Account", viewModel);
        }

        private async Task<AccountViewModel> PopulateAccountInfoAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user is not null)
            {
                return new AccountViewModel
                {
                    Profile = await PopulateProfileAsync(),
                    Details = await PopulateDetailsAsync()
                };
            }

            return null!;
        }

        private async Task<DetailsViewModel> PopulateDetailsAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user is not null)
            {
                return new DetailsViewModel
                {
                    BasicInfo = await PopulateBasicInfoAsync(),
                    //Address = await PopulateAddressInfoAsync()
                };
            }

            return null!;
        }

        private async Task<BasicInfoViewModel> PopulateBasicInfoAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user is not null)
            {
                return new BasicInfoViewModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email!,
                    Phone = user.PhoneNumber!,
                    Bio = user.Bio!
                };
            }

            return null!;
        }

        //private async Task<AddressViewModel> PopulateAddressInfoAsync()
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user is not null)
        //    {
        //        return new AddressViewModel
        //        {
        //            AddressLine_1 = user.Address!.StreetLine_1,
        //            AddressLine_2 = user.Address.StreetLine_2!,
        //            PostalCode = user.Address.PostalCode,
        //            City = user.Address.City
        //        };
        //    }

        //    return null!;
        //}

        private async Task<ProfileViewModel> PopulateProfileAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user is not null)
            {
                return new ProfileViewModel
                {
                    ProfileImage = user.ProfileImage,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email!,
                };
            }
            return null!;
        }
    }
}
