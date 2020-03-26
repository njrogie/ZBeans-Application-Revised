using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZBeans_Revised.Areas.Identity.Data;

namespace ZBeans_Revised.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ZBeans_RevisedUser> _userManager;
        private readonly SignInManager<ZBeans_RevisedUser> _signInManager;

        public IndexModel(
            UserManager<ZBeans_RevisedUser> userManager,
            SignInManager<ZBeans_RevisedUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "First Name")]
            public string FName { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Last Name")]
            public string LName { get; set; }
            [Required]
            [Display(Name = "ServSafe Certified")]
            public bool ServSafe { get; set; } = false;
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Daily Availibility")]
            public string[] DailyAvailibility { get; set; } = new string[7];
           
            [Required]
            [Display(Name = "Employee Level")]
            public ZBeans_RevisedUser.EmployeeLevel Elevel = ZBeans_RevisedUser.EmployeeLevel.Entry;
        }

        private async Task LoadAsync(ZBeans_RevisedUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                FName = user.FName,
                LName = user.LName,
                ServSafe = user.ServSafe,
                DailyAvailibility = user.DailyAvailibility,
                Elevel = user.Elevel
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }


            await _userManager.UpdateAsync(user);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
