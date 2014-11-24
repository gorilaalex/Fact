using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Others;

namespace Facturi.Controllers
{
    public class BaseController : Controller
    {
        protected const string GENERIC_ERROR_MESSAGE = "An error has occured, please contact Fact support!";
        protected const string SESSION_EXPIRED = "Your session has timed out. Please login again.";
        protected const string INVALID_DATA = "Invalid data";
        public const string SessionCookieId = "ASP.NET_SessionId";
        public const int DEFAULT_PAGE_SIZE = 30;

        protected BaseViewModel GetDefaultUnsuccesfullViewModel()
        {
            return new BaseViewModel()
            {
                IsSuccess = false,
                Message = GENERIC_ERROR_MESSAGE,
            };
        }

        protected BaseViewModel GetDefaultInvalidDataViewModel()
        {
            return new BaseViewModel()
            {
                IsSuccess = false,
                Message = INVALID_DATA,
            };
        }

        protected BaseViewModel GetDefaultSessionExpiredViewModel()
        {
            return new BaseViewModel()
            {
                IsSuccess = false,
                IsSessionExpired = true,
                Message = SESSION_EXPIRED
            };
        }

        protected bool ValidateCaptcha(HttpRequestBase request, string challenge, string response, out string errorMessage)
        {
            Recaptcha.RecaptchaValidator captchaValidtor = new Recaptcha.RecaptchaValidator
            {
                PrivateKey = ConfigurationManager.AppSettings["ReCaptchaPrivateKey"],
                RemoteIP = request.UserHostAddress,
                Challenge = challenge,
                Response = response
            };
            Recaptcha.RecaptchaResponse recaptchaResponse = captchaValidtor.Validate();
            errorMessage = recaptchaResponse.ErrorMessage;
            return recaptchaResponse.IsValid;
        }
    }
}
