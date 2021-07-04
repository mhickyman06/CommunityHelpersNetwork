using HelpersNetwork.Models;
using HelpersNetwork.Models.SeedRoles;
using HelpersNetwork.Services;
using HelpersNetwork.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpersNetwork.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> logger;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IMailService mailService;

        public AccountController(ILogger<AccountController> logger,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IMailService mailService
            )
        {
            this.logger = logger;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.mailService = mailService;
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
            if (ModelState.IsValid)
            {
                var userExists = await userManager.FindByEmailAsync(model.Email);

                if (userExists == null)
                {
                    var enumdisplaystatus = (Sex)model.Sex;
                    string enumname = enumdisplaystatus.ToString();

                    //var user = new ApplicationUser()
                    //{
                        
                    //    Name = model.Name,
                    //    Age = model.Age,
                    //    Gender = enumname,
                    //    Address = model.Address,
                    //    PhoneNumber = model.PhoneNumber,
                    //    State = model.State,
                    //    LocalGovt = model.LocalGovt,
                    //    Nationality = model.Nationality,
                    //    Phone  = model.PhoneNumber,
                    //    Email = model.Email,
                    //    SecurityStamp = Guid.NewGuid().ToString(),
                    //    UserName = model.Email,
                    //};
                    var user = new ApplicationUser
                    {
                        Email = model.Email,
                        UserName = model.Email,
                        Name = model.Name,
                        Age = model.Age,
                        Gender = enumname,
                        Religion = model.Religion,
                        PhoneNumber = model.PhoneNumber,
                        Address = model.Address,
                        State = model.State,
                        LocalGovt = model.LocalGovt,
                        Nationality = model.Nationality,
                        SecurityStamp = Guid.NewGuid().ToString(),
                    };

                    if (!await roleManager.RoleExistsAsync(ConstantRoles.User))
                        await roleManager.CreateAsync(new IdentityRole(ConstantRoles.User));

                   
                    var result = await userManager.CreateAsync(user, model.ConfirmPassword);
              
                    if (result.Succeeded)
                    {
                       
                       await userManager.AddToRoleAsync(user, ConstantRoles.User);
                        
                        var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                        var confirmationLink = Url.Action(nameof(ConfirmEmail),
                            "Account", new { token, email = user.Email }, Request.Scheme);

                        var mailRequest = new MailRequest
                        {
                            Body = confirmationLink,
                            Subject = "Confirmation Link",
                            ToEmail = user.Email
                        };

                        //ovalshapenigeria@gmail.com
                        var mailRequestOwner = new MailRequest
                        {
                            Body = $"A user with the name {user.Name}, and  Phone Number {user.PhoneNumber} Just Registered on your application",
                            Subject = " SuccessfullY Registered User",
                            ToEmail = "michealmadu73@gmail.com"
                        };

                        await mailService.SendEmailAsync(mailRequest);

                        await mailService.SendEmailAsync(mailRequestOwner);

                        logger.LogInformation("A user has just been created");

                        return RedirectToAction(nameof(SuccessRegistration));

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
                }
            }
         
            return View(model);
        }

        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                var user = await userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    return View(nameof(UserNotFound));
                }
                else
                {

                    var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.IsPersistent, false);
                    if (result.Succeeded)
                    {
                        if (returnUrl != null && Url.IsLocalUrl(returnUrl))
                        {
                            logger.LogInformation("User is  Logged in");
                            return RedirectToAction(returnUrl);
                        }

                        if (await userManager.IsInRoleAsync(user, ConstantRoles.User))
                        {
                            await signInManager.SignInAsync(user, isPersistent: model.IsPersistent);
                            return RedirectToAction("Index", "Home");
                        }
                        else if(await userManager.IsInRoleAsync(user, ConstantRoles.Admin))
                        {
                            await signInManager.SignInAsync(user, isPersistent: model.IsPersistent);
                            return RedirectToAction("Index", "Administrator");
                        }
                        else
                        {
                            await signInManager.SignInAsync(user, isPersistent: model.IsPersistent);
                            logger.LogInformation("User is  Logged in");
                            return RedirectToAction("Administrator", "Index");
                        }
                    }
                    ModelState.AddModelError("", "Invalid Input");
                }
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            logger.LogInformation("User is Logged out");
            return RedirectToAction("Index", "Home");
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

        [HttpPost("GetStateLocalGovt")]
        [Route("GetStateLocalGovt")]
        [AllowAnonymous]
        public IActionResult GetStateLocalGovt(int? Id)
        {

            if (Id == null)
            {
                return NotFound();
            }
            var enumdisplaystatus = (States)Id;
            string enumname = enumdisplaystatus.ToString();

            List<string> Model = new List<string>();
            StatesLocalGovt stl = new StatesLocalGovt();

            for (int i = 0; i < StatesLocalGovt.allstateslocalgovt.Count(); i++)
            {
                if (Id == i)
                {
                    Model = StatesLocalGovt.allstateslocalgovt.ElementAt(i);
                }
            }
            return Ok(new { Model, enumname, Id });
        }

        [HttpGet]
        [Route("UserNotFound")]
        public IActionResult UserNotFound()
        {
            return View();
        }
    }
}