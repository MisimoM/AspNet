using Business.Services;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.Account;

namespace Presentation.Controllers
{
    [Authorize]
    public class AccountController(UserManager<UserEntity> userManager, AddressService addressService) : Controller
    {
        private readonly UserManager<UserEntity> _userManager = userManager;
        private readonly AddressService _addressService = addressService;

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

        [HttpPost]
        [Route("/Account/Details")]
        public async Task<IActionResult> UpdateDetails(AccountViewModel viewModel)
        {

            if (viewModel.Details!.BasicInfo is not null)
            {
                if (
                   viewModel.Details.BasicInfo.FirstName is not null &&
                   viewModel.Details.BasicInfo.LastName is not null &&
                   viewModel.Details.BasicInfo.Email is not null
                   )
                {
                    var user = await _userManager.GetUserAsync(User);
                    if (user is not null)
                    {
                        user.FirstName = viewModel.Details.BasicInfo.FirstName;
                        user.LastName = viewModel.Details.BasicInfo.LastName;
                        user.Email = viewModel.Details.BasicInfo.Email;
                        user.PhoneNumber = viewModel.Details.BasicInfo.Phone;
                        user.Bio = viewModel.Details.BasicInfo.Bio;

                        //För att kunna ändra email/username och logga in.
                        user.NormalizedEmail = viewModel.Details.BasicInfo.Email;
                        user.UserName = viewModel.Details.BasicInfo.Email;
                        user.NormalizedUserName = viewModel.Details.BasicInfo.Email;

                        var result = await _userManager.UpdateAsync(user);
                        if (!result.Succeeded)
                        {
                            ModelState.AddModelError("IncorrectValues", "Something went wrong!");
                        }
                    }
                }
            }

            if (viewModel.Details.Address is not null)
            {
                if (
                    viewModel.Details.Address.AddressLine_1 is not null &&
                    viewModel.Details.Address.PostalCode is not null &&
                    viewModel.Details.Address.City is not null
                    )
                {
                    var user = await _userManager.GetUserAsync(User);
                    if (user!.AddressId is null)
                    {
                        var addressEntity = new AddressEntity
                        {
                            AddressLine_1 = viewModel.Details.Address.AddressLine_1,
                            AddressLine_2 = viewModel.Details.Address.AddressLine_2,
                            PostalCode = viewModel.Details.Address.PostalCode,
                            City = viewModel.Details.Address.City
                        };

                        await _addressService.CreateAddressAsync(addressEntity);

                        user.AddressId = addressEntity.Id;

                        await _userManager.UpdateAsync(user);
                    }
                    else
                    {
                        await _addressService.GetAddressAsync(user.AddressId);

                        user.Address!.AddressLine_1 = viewModel.Details.Address.AddressLine_1;
                        user.Address.AddressLine_2 = viewModel.Details.Address.AddressLine_2;
                        user.Address.PostalCode = viewModel.Details.Address.PostalCode;
                        user.Address.City = viewModel.Details.Address.City;

                        await _userManager.UpdateAsync(user);
                    }
                }
            }

            viewModel = await PopulateAccountInfoAsync();

            return View("Account", viewModel);
        }

        private async Task<AccountViewModel> PopulateAccountInfoAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            
            if (user is null)
            {
                return null!;
            }

            var accountViewModel = new AccountViewModel
            {
                Profile = new ProfileViewModel
                {
                    ProfileImage = user.ProfileImage,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email!
                },
                Details = new DetailsViewModel
                {
                    BasicInfo = new BasicInfoViewModel
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email!,
                        Phone = user.PhoneNumber!,
                        Bio = user.Bio!
                    },
                }
            };

            var userAddress = await _addressService.GetAddressAsync(user.AddressId);

            if (userAddress is null)
            {
                accountViewModel.Details.Address = new AddressViewModel
                {
                    AddressLine_1 = string.Empty,
                    AddressLine_2 = string.Empty,
                    PostalCode = string.Empty,
                    City = string.Empty
                };

            }
            else
            {
                accountViewModel.Details.Address = new AddressViewModel
                {
                    AddressLine_1 = user.Address!.AddressLine_1,
                    AddressLine_2 = user.Address.AddressLine_2!,
                    PostalCode = user.Address.PostalCode,
                    City = user.Address.City
                };
            }

            return accountViewModel;
        }
    }
}
