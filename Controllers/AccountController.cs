using HelpersNetwork.Models;
using HelpersNetwork.Models.SeedRoles;
using HelpersNetwork.Services;
using HelpersNetwork.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Manage.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

                        try
                        {
                            await mailService.SendEmailAsync(mailRequest);
                            await mailService.SendEmailAsync(mailRequestOwner);
                            logger.LogInformation("A user has just been created");
                            return RedirectToAction(nameof(SuccessRegistration));
                        }
                        catch(Exception ex)
                        {
                            logger.LogError(ex.Message);
                            //userManager.DeleteAsync()
                        }                                        
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

            TempData["ShowResend"] = false;
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
                if (!user.EmailConfirmed)
                {
                    logger.LogWarning("User email is not confirmed");
                    ModelState.AddModelError("", "Email is not confirmed, Please click the resend verification button");
                    TempData["ShowResend"] = true;
                    //TempData["UserId"] = user.Id;
                    logger.LogInformation(TempData["ShowResend"].ToString());
                    return View();
                }

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
            }
            TempData["ShowResend"] = false;
            ModelState.AddModelError("", "Invalid Input");  
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
        [Route("Unconfirmedemail")]
        public IActionResult Unconfirmedemail()
        {
            return View();
        }

        [HttpPost]
        [Route("Unconfirmedemail")]
        public async Task<IActionResult> Unconfirmedemail(UnconfirmedEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    logger.LogError("User with the email: " + model.Email + " was not found");
                    ModelState.AddModelError("", "Invalid user, please enter a valid email and try again");
                    return View(model);
                }
                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action(nameof(ConfirmEmail),
                    "Account", new { token, email = user.Email }, Request.Scheme);

                var mailRequest = new MailRequest
                {
                    Body = confirmationLink,
                    Subject = "Confirmation Link",
                    ToEmail = user.Email
                };
               
                await mailService.SendEmailAsync(mailRequest);
                logger.LogInformation("the specified user with the email: "+ user.Email +" has been confirmed");
                return RedirectToAction(nameof(SuccessRegistration));
              
            }
            return View();
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
            if (signInManager.IsSignedIn(User) && User.IsInRole(ConstantRoles.Admin))
            {
                return View("ListUsers", "Administrator");
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





        [HttpGet]
        [Route("ForgotPassword")]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [Route("ForgotPassword")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel forgotPasswordModel)
        {
            if (!ModelState.IsValid)
                return View(forgotPasswordModel);
            var user = await userManager.FindByEmailAsync(forgotPasswordModel.Email);
            if (user == null)
                return RedirectToAction(nameof(ForgotPasswordConfirmation));
            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            //var callback = Url.Action(nameof(ResetPassword), "Account", new { token, email = user.Email }, Request.Scheme);

            var callback = Url.Action(nameof(ResetPassword),
                          "Account", new { token, email = user.Email }, Request.Scheme);

            //var message = new Message(new string[] { user.Email }, "Reset password token", callback, null);
            //await _emailSender.SendEmailAsync(message);
         
            var mailRequest = new MailRequest
            {
                Body = callback,
                Subject = "Reset password token",
                ToEmail = user.Email
            };

             await this.mailService.SendEmailAsync(mailRequest);

            return RedirectToAction(nameof(ForgotPasswordConfirmation));
        }

        [HttpGet]
        [Route("ForgotPasswordConfirmation")]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }





        [HttpGet]
        [Route("ResetPassword")]
        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPasswordModel { Token = token, Email = email };
            return View(model);
        }

        [HttpPost]
        [Route("ResetPassword")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            if (!ModelState.IsValid)
                return View(resetPasswordModel);

            var user = await userManager.FindByEmailAsync(resetPasswordModel.Email);
            if (user == null)
                RedirectToAction(nameof(ResetPasswordConfirmation));

            var resetPassResult = await userManager.ResetPasswordAsync(user, resetPasswordModel.Token, resetPasswordModel.Password);
            if (!resetPassResult.Succeeded)
            {
                foreach (var error in resetPassResult.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return View();
            }

            return RedirectToAction(nameof(ResetPasswordConfirmation));
        }

        [HttpGet]
        [Route("ResetPasswordConfirmation")]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
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