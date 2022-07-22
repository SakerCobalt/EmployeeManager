using EmployeeManager.RazorPages.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace EmployeeManager.RazorPages.Pages.Security
{
    public class SignOutModel : PageModel
    {
        private readonly SignInManager<AppIdentityUser> signInManager;
        public SignOutModel(SignInManager<AppIdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await signInManager.SignOutAsync();
            return RedirectToPage("/Security/SignIn");
        }

    }
}
