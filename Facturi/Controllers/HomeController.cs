using DataAcces.Entities;
using DataAcces.Repository;
using DataAccessAbstraction;
using DataAccessAbstraction.Entities;
using DataAccessAbstraction.Repository;
using Facturi.App_FormsAuth;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;
using ViewModel.Others;
using ViewModels.Facts;
using ViewModels.Unions;
using ViewModels.User;

namespace Facturi.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        [HttpGet]
        public ActionResult MyDashboard()
        {
            BaseViewModel model;
            UserFormsPrincipal principal = UserFormsPrincipal.GetPrincipal("Principal", HttpContext.Session);
            try
            {
                if (principal != null && principal is UserFormsPrincipal && (principal.Identity as UserFormsIdentity).User != null)
                {

                    model = new BaseViewModel();
                    model.IsSuccess = true;
                    model.Message = "My Dashboard";

                    return Json(model, JsonRequestBehavior.AllowGet);
                }
                else return Json(GetDefaultSessionExpiredViewModel(), JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                model = new BaseViewModel();
                model.IsSuccess = false;
                model.Message = ex.Message;
                return Json(model, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult MyProfile()
        {
            BaseViewModel model;
            UserFormsPrincipal principal = UserFormsPrincipal.GetPrincipal("Principal", HttpContext.Session);
            try
            {
                if (principal != null && principal is UserFormsPrincipal && (principal.Identity as UserFormsIdentity).User != null)
                {

                    model = new BaseViewModel();
                    model.IsSuccess = true;
                    model.Message = "My Profile";

                    return Json(model, JsonRequestBehavior.AllowGet);
                }
                else return Json(GetDefaultSessionExpiredViewModel(), JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                model = new BaseViewModel();
                model.IsSuccess = false;
                model.Message = ex.Message;
                return Json(model, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult MyCompany()
        {
            BaseViewModel model;
            UserFormsPrincipal principal = UserFormsPrincipal.GetPrincipal("Principal", HttpContext.Session);
            try
            {
                if (principal != null && principal is UserFormsPrincipal && (principal.Identity as UserFormsIdentity).User != null)
                {

                    model = new BaseViewModel();
                    model.IsSuccess = true;
                    model.Message = "My Company";

                    return Json(model, JsonRequestBehavior.AllowGet);
                }
                else return Json(GetDefaultSessionExpiredViewModel(), JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                model = new BaseViewModel();
                model.IsSuccess = false;
                model.Message = ex.Message;
                return Json(model, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult MyAccount()
        {
            BaseViewModel model;
            UserFormsPrincipal principal = UserFormsPrincipal.GetPrincipal("Principal", HttpContext.Session);
            try
            {
                if (principal != null && principal is UserFormsPrincipal && (principal.Identity as UserFormsIdentity).User != null)
                {

                    model = new BaseViewModel();
                    model.IsSuccess = true;
                    model.Message = "My Account";

                    return Json(model, JsonRequestBehavior.AllowGet);
                }
                else return Json(GetDefaultSessionExpiredViewModel(), JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                model = new BaseViewModel();
                model.IsSuccess = false;
                model.Message = ex.Message;
                return Json(model, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult x() 
            {
            UserFormsPrincipal principal = UserFormsPrincipal.GetPrincipal("Principal", HttpContext.Session);
            if (principal != null && principal is UserFormsPrincipal && (principal.Identity as UserFormsIdentity).User != null)
            {
                UserViewModel userVM = principal.UserIdentity;
                CompanyViewModel companyVM = new CompanyViewModel();
                ICompanyRepository companyRepository = new CompanyRepository(ConfigurationManager.AppSettings["RootDatabaseConnectionString"]);
                IOperationResponse<ICompany> companyResponse = companyRepository.GetCompany(userVM.Id);
                if (companyResponse.Value != null)
                {
                    companyVM = new CompanyViewModel(companyResponse.Value);
                }
                CompanyUserUnionViewModel companyUserUnionModel = new CompanyUserUnionViewModel();
                if (companyVM != null && userVM != null)
                {
                    companyUserUnionModel = new CompanyUserUnionViewModel(userVM, companyVM);
                }
                return View(companyUserUnionModel);
            }
            else return RedirectToAction("Login", "Account");
        }

        public ActionResult Index()
        {
                UserFormsPrincipal principal = UserFormsPrincipal.GetPrincipal("Principal", HttpContext.Session);
                if (principal != null && principal is UserFormsPrincipal && (principal.Identity as UserFormsIdentity).User != null)
                {
                    return View();
                }

                else return RedirectToAction("Login", "Account");
        }


    }
}
