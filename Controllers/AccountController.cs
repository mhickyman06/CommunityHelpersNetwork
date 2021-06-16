using HelpersNetwork.Models;
using HelpersNetwork.Models.SeedRoles;
using HelpersNetwork.Services;
using HelpersNetwork.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace HelpersNetwork.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> logger;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        //private readonly IMailService mailService;

        public AccountController(ILogger<AccountController> logger,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager
            //IMailService mailService
            )
        {
            this.logger = logger;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            //this.mailService = mailService;
        }
        
        [HttpGet]
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var userExists = await userManager.FindByEmailAsync(model.Email);

            if (userExists != null)
                return NotFound();


            var enumdisplaystatus = (Sex)model.Sex;
            string enumname = enumdisplaystatus.ToString();

            ApplicationUser user = new ApplicationUser()
            {
                Name = model.Name,
                Age = model.Age,
                Sex = enumname,
                Address = model.Address,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email,                              
            };
            var result = await userManager.CreateAsync(user, model.ConfirmPassword);
            if (!await roleManager.RoleExistsAsync(ConstantRoles.User))
                await roleManager.CreateAsync(new IdentityRole(ConstantRoles.User));

            if (await roleManager.RoleExistsAsync(ConstantRoles.User))
            {
                await userManager.AddToRoleAsync(user, ConstantRoles.User);
            }
            if (!result.Succeeded)
            {
                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action(nameof(ConfirmEmail),
                    "Account", new { token, email = user.Email }, Request.Scheme);

                var mailRequest = new MailRequest
                {
                    Body = confirmationLink,
                    Subject = "Confirmation Link",
                    ToEmail = user.Email
                };

                //await mailService.SendEmailAsync(mailRequest);
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    logger.LogTrace("Account/Controller");
                    logger.LogError(error.Description);
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
        [HttpGet]
        [Route("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            if(email == null)
            {
                return View("Error");
            }

            var user = await userManager.FindByEmailAsync(email);

            var result = await userManager.ConfirmEmailAsync(user, token);         

           
           
            if (await userManager.IsInRoleAsync(user,ConstantRoles.User))
            {
                return View(nameof(ConfirmEmail));
            }
            //else if (user.AccountRole == ConstantRoles.Spellers)
            //{
            //    return RedirectToAction("GetAllSpellers", "School", new { Message = "You Have Succesfully Registered A Speller" });
            //}
            return View("Error");
        }

        [HttpGet]
        [Route("SuccessRegistration")]
        public IActionResult SuccessRegistration()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("IsEmailInUsed")]
        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsEmailInUsed(string Email)
        {
            var result = await userManager.FindByEmailAsync(Email);

            if (result == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"the {Email} is already in use please choose an another email ");
            }

        }
    }
}