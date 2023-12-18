using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CapstoneBlazorServerSite.Models;
using CapstoneBlazorServerSite.Data;


namespace CapstoneBlazorServerSite.Areas.Identity.Pages.Account
{
    public class LoginRegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DataContext _db;

        public LoginRegisterModel(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, DataContext db)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _db = db;
        }

        
        public RegisterInputModel RegisterInput { get; set; }

        public LoginInputModel LoginInput { get; set; }

        public string ReturnUrl { get; set; }

        public void OnGet()
        {
            ReturnUrl = Url.Content("~/");
        }

        public async Task<IActionResult> OnPostRegisterAsync(RegisterInputModel model)
        {
            ReturnUrl = Url.Content("~/");
            if (ModelState.IsValid)
            {
                var identity = new ApplicationUser { UserName = model.Name, Email = model.Email };
                var result = await _userManager.CreateAsync(identity, model.Password);

                if (result.Succeeded)
                {
                    _db.CareerStats.Add(new CareerStats { PlayerName = model.Name, PlayerId = identity.Id });
                    _db.SaveChanges();
                    await _signInManager.SignInAsync(identity, isPersistent: false);
                    return LocalRedirect(ReturnUrl);
                }
                return Page();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostLoginAsync(LoginInputModel model)
        {
            ReturnUrl = Url.Content("~/");

            if (ModelState.IsValid)
            {
                ApplicationUser? user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    return Page();
                }
                else
                {
                    var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, isPersistent: false, lockoutOnFailure: false);
                    if (result.Succeeded) return LocalRedirect(ReturnUrl);
                }

            }
            return Page();
        }

        public class RegisterInputModel
        {
            [Required]
            public string Name { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        public class LoginInputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }
}
