using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using whitelagon.Web.ViewModel;
using Whitelagon.admin.Entities;
using Whitelagon.Application.Common;
using Whitelagon.Application.Common.Utility;

namespace whitelagon.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly Iunitofwork _unit;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole>   _roleManager;
        public AccountController(Iunitofwork unit, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _unit = unit;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
       

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginVM.Email, loginVM.Password, loginVM.RememberMe, false);

                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(loginVM.RedirectUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return LocalRedirect(loginVM.RedirectUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt");
                }
            }
            return View(loginVM);
        }

        [HttpGet]
        public IActionResult Register()
        {
            RegisterVM registerVM = new RegisterVM
            {
                Rolelist = _roleManager.Roles
                            .Select(r => new SelectListItem
                            {
                                Text = r.Name,
                                Value = r.Name
                            }).ToList()
            };

            return View(registerVM);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                var user = new AppIdentitiy()
                {
                    UserName = registerVM.Email,
                    Email = registerVM.Email,
                    PhoneNumber = registerVM.Phonenumber,
                    Name = registerVM.Name,
                    NormalizedUserName= registerVM.Email.ToUpper(),
                    EmailConfirmed = true,
                    CreateAt = DateTime.Now,

                };
                var result = await _userManager.CreateAsync(user, registerVM.Password);
               
                if (result.Succeeded)
                {
                    if(registerVM.Role == null)
                    {
                       await _userManager.AddToRoleAsync(user, SD.Role_User);
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, registerVM.Role);
                    }
                  
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    
              
                    if(string.IsNullOrEmpty(registerVM.RedirectUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return LocalRedirect(registerVM.RedirectUrl);
                    }
                  
                }
                
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
               
               
            }
             
            return View(registerVM);
         
        }
        
       public IActionResult Logout()
        {            
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        
        
        public IActionResult AccessDenied()
        {
            return View();
        }


    }
}
