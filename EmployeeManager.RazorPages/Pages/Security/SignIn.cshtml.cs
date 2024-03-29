using EmployeeManager.RazorPages.Models;
using EmployeeManager.RazorPages.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManager.RazorPages.Pages.Security
{
    public class SignInModel : PageModel
    {
        private readonly SignInManager<AppIdentityUser> signInManager;
        [BindProperty]
        public SignIn SignInData { get; set; }

        public SignInModel(SignInManager<AppIdentityUser> signInManager)
        {
            this.signInManager = signInManager;
            
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(SignInData.UserName, SignInData.Password, SignInData.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToPage("/EmployeeManager/List");
                }
                else ModelState.AddModelError("", "Invalid user name or password");

                
            }
            return Page();
        }
    }
}
