using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolBusAPI.Models;

namespace SchoolBusAPI.Controllers
{
    /// <summary>
    /// error controller 
    /// </summary>
    public class ErrorController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        [Route("/error/{errorCode}")]
        public IActionResult Error([FromRoute]int errorCode)
        {
            string errorTitle = "Unknown Error";
            string errorMessage = "An unknown error has occoured. Please try again later.";
            if (Request.Headers["Accept"].ToString() != null && Request.Headers["Accept"].ToString() == "application/json")
            {
                Error error = new Error(errorTitle, errorCode, errorMessage);
                switch (errorCode)
                {
                    case 400:
                        error.errorTitle = "Bad Request";
                        error.errorMessage = "Invalid input.";
                        break;
                    case 403:
                        error.errorTitle = "Permission Denied";
                        error.errorMessage = "The current user does not have the necessary permissions to complete this request.";
                        break;
                    case 404:
                        error.errorTitle = "Not Found";
                        error.errorMessage = "The requested data was not found.";
                        break;
                    default:
                        error.errorTitle = errorTitle;
                        error.errorMessage = errorMessage;
                        break;
                }
                return new ObjectResult(error);
            }
            else
            {
                ViewBag.ErrorCode = errorCode;
                switch (errorCode)
                {   
                    case 503:
                        ViewBag.errorTitle = "Service Temporarily Unavailable";
                        ViewBag.errorMessage = "The PDF service is overloaded and temporarily unavailable. Please wait a few minutes and try your request again.";
                        return View("Views/503Error.cshtml");
                    case 404:
                        ViewBag.errorTitle = "Print Permit Fail";
                        ViewBag.errorMessage = "Unable to handle your request. School bus record has not found.";
                        return View("Views/404Error.cshtml");
                    default:
                        ViewBag.errorTitle = errorTitle;
                        ViewBag.errorMessage = errorMessage;
                        return View("Views/Error.cshtml");
                }
            }
        }
    }
}
