using Google.Apis.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
namespace HelpersNetwork.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var statuscoderesult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the resource you required could not be found";
                    logger.LogWarning($"404 Error occured Path = {statuscoderesult.OriginalPath}" +
                        $" and QueryString {statuscoderesult.OriginalQueryString}");
                    //ViewBag.Path = statuscoderesult.OriginalPath;
                    //ViewBag.Qs = statuscoderesult.OriginalQueryString;
                    break;
            }
            return View("NotFound");
        }

        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exceptiondetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            //ViewBag.ExceptionPath = exceptiondetails.Path;
            //ViewBag.ExceptionMessage = exceptiondetails.Error.Message;
            //ViewBag.StackTrace = exceptiondetails.Error.StackTrace;
            logger.LogError($"The path {exceptiondetails.Path} threw an exception {exceptiondetails.Error}");
            return View("Error");
        }
    }
}