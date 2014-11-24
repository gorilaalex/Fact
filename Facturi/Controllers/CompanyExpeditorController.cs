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
using System.Web;
using System.Web.Mvc;
using ViewModel.Others;
using ViewModels.User;

namespace Facturi.Controllers
{
    public class CompanyExpeditorController : BaseController
    {
        //
        // GET: /Company/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult AddEditCompany(Company company) {
             BaseViewModel model;
            try
            {
                UserFormsPrincipal principal = UserFormsPrincipal.GetPrincipal("Principal", HttpContext.Session);
                if (principal != null && principal is UserFormsPrincipal && (principal.Identity as UserFormsIdentity).User != null)
                {
                    model = new CompanyViewModel(company);
                    ICompanyRepository companyRepository = new CompanyRepository(ConfigurationManager.AppSettings["RootDatabaseConnectionString"]);
                    if (company.CIF != null) company.CUI = company.CIF;
                    else company.CIF = company.CUI;


                    if (company.Id != Guid.Empty)
                    {
                        IOperationResponse<ICompany> companyResponse = companyRepository.Update(company);
                        if (companyResponse.IsSuccess && companyResponse.Value != null)
                        {
                            model.IsSuccess = true;

                        }
                        else
                        {
                            model.IsSuccess = false;
                        }
                    }
                    else
                    {
                        company.UserId = principal.UserIdentity.Id;
                        IOperationResponse<ICompany> companyResponse = companyRepository.Insert(company);
                        if (companyResponse.IsSuccess && companyResponse.Value != null)
                        {
                            model.IsSuccess = true;
                        }
                        else
                        {
                            model.IsSuccess = false;
                        }
                    }
                }
                else
                {
                    model = new BaseViewModel();
                    model.IsSuccess = false;
                    model.Message = "Your session is expired.";
                }
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                model = new BaseViewModel();
                model.IsSuccess = false;
                model.Message = ex.Message;
                return Json(model, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetCompanies() 
        {
            return Json("x", JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCompany()
        {
            return Json("x", JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddEditExpeditor()
        {
            return Json("x", JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteExpeditor() 
        {
            return Json("x", JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetExpeditors() 
        {
            return Json("x", JsonRequestBehavior.AllowGet);
        }


    }
}
