using DataAcces.Entities;
using DataAcces.Repository;
using DataAccessAbstraction;
using DataAccessAbstraction.Entities;
using DataAccessAbstraction.Repository;
using Facturi.App_FormsAuth;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ViewModel;
using ViewModel.Others;
using ViewModels.User;

namespace Facturi.Controllers
{
    public class AccountController : BaseController
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("index","Home");
            else return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginViewModel loginModel)
        {
            UserViewModel model = new UserViewModel() ;
            try
            {
                if (loginModel != null && loginModel.Username != null && loginModel.Password != null)
                {
                    IUserRepository repository = new UserRepository(ConfigurationManager.ConnectionStrings["RootDatabaseConnectionString"].ConnectionString);
                    IOperationResponse<IUser> response = repository.GetLogin(loginModel.Username, loginModel.Password);
                    if (response.IsSuccess && response.Value !=null)
                    {
                        model = new UserViewModel(response.Value);
                        model.IsSuccess = true;
                        model.ReturnUrl = "/home/index" ;//new UrlHelper(Request.RequestContext).Action("Index","Home");
                        FormsAuthentication.SetAuthCookie(loginModel.Username, loginModel.RememberMe);
                        UserMembershipUser membershipUser = new UserMembershipUser(model);
                        UserFormsPrincipal.CachePrincipalInSession("Principal", membershipUser, HttpContext.Session);
                        
                    }
                    else
                    {
                        model.IsSuccess = false;
                        model.Message = "Something went wrong to login. Please try again.s";
                    }   
                }
                else
                {
                    model.IsSuccess = false;
                    model.Message = "Something is wrong with username/password.";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Message = ex.Message;

            }
            return Json(model,JsonRequestBehavior.AllowGet);
        }

        
        [HttpGet]
        public JsonResult LogOut()
        {
            BaseViewModel model = new BaseViewModel()
            {
                IsSuccess = true,
            };

            try
            {
                UserFormsPrincipal principal = UserFormsPrincipal.GetPrincipal("Principal", HttpContext.Session);
                if (principal != null && principal is UserFormsPrincipal && (principal.Identity as UserFormsIdentity).User != null)
                {
                    FormsAuthentication.SignOut();
                    Session.Abandon();
                    var cookie = Response.Cookies[FormsAuthentication.FormsCookieName];
                    if (cookie != null)
                        cookie.Path = Request.ApplicationPath;
                    Response.Cookies.Add(new HttpCookie(SessionCookieId));

                    model.ReturnUrl = "/account/login";
                }
                else
                {
                    model.IsSessionExpired = true;
                    model.ReturnUrl = "/account/login";
                }
            }
            catch (Exception ex)
            {
                model.ReturnUrl = "/account/login";
                model.IsSuccess = false;
                
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistrationViewModel request)
        {
            BaseViewModel model = new BaseViewModel();
            try
            {
                IUser user = new User();
                user.Username = request.Username;
                user.Password = request.Password;
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                string message;
               if (!ValidateCaptcha(Request, request.Challenge, request.Response, out message))
                {
                    var returnModel = new BaseViewModel()
                    {
                        IsSuccess = false,
                        Message = message
                    };
                    return Json(returnModel);
                }
                
                if (user != null && user.Username != null && user.Password != null)
                {


                    IUserRepository repository = new UserRepository(ConfigurationManager.ConnectionStrings["RootDatabaseConnectionString"].ConnectionString);
                    IOperationResponse<bool> check = repository.CheckIfUserExists(user.Username);
                    if (check.IsSuccess)
                    {
                        IOperationResponse<IUser> response = repository.Insert(user);
                        if (response.IsSuccess && response.Value != null)
                        {
                            model = new UserViewModel(response.Value);
                            model.IsSuccess = true;
                        }
                        else
                        {
                            model.IsSuccess = false;
                            model.Message = response.Message;
                        }
                    }
                    else
                    {
                        model.IsSuccess = false;
                        model.Message = check.Message;
                    }
                    
                    
                }
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
                model.IsSuccess = false;
            }
            return Json(model,JsonRequestBehavior.AllowGet);
        }
    }
}
