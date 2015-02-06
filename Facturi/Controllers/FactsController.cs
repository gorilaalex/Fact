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
using System.Web.Helpers;
using System.Web.Mvc;
using ViewModel.Others;
using ViewModels.Facts;

namespace Facturi.Controllers
{
    public class FactsController : Controller
    {
        //
        // GET: /Facts/

        public ActionResult Index()
        {
            UserFormsPrincipal principal = UserFormsPrincipal.GetPrincipal("Principal", HttpContext.Session);
            if (principal != null && principal is UserFormsPrincipal && (principal.Identity as UserFormsIdentity).User != null)
            {
                return View();
            }
            else return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public JsonResult AddFact(IFact fact)
        {
            try{
                BaseViewModel model = new BaseViewModel();
                UserFormsPrincipal principal = UserFormsPrincipal.GetPrincipal("Principal", HttpContext.Session);
                if (principal != null && principal is UserFormsPrincipal && (principal.Identity as UserFormsIdentity).User != null)
                {
                    IFactRepository repository = new FactRepository(ConfigurationManager.ConnectionStrings["RootDatabaseConnectionString"].ConnectionString);
                    IOperationResponse<IFact> response = repository.Insert(fact);
                    if (response.IsSuccess && response.Value != null)
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
                    model.IsSuccess = false;
                    model.IsSessionExpired = true;

                }
                    return Json(model, JsonRequestBehavior.AllowGet);
                }
        catch (Exception ex)
            {
                BaseViewModel model = new BaseViewModel();
                model.IsSuccess = false;
                return Json(model, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GetFacts(string id)
        {
            try
            {
                BaseViewModel model = new BaseViewModel();
                UserFormsPrincipal principal = UserFormsPrincipal.GetPrincipal("Principal", HttpContext.Session);
                if (principal != null && principal is UserFormsPrincipal && (principal.Identity as UserFormsIdentity).User != null)
                {
                    IFactRepository repository = new FactRepository(ConfigurationManager.ConnectionStrings["RootDatabaseConnectionString"].ConnectionString);
                    IOperationResponse<List<IFact>> response = repository.GetAllByUser(principal.UserIdentity.Id);
                    if (response.IsSuccess && response.Value != null)
                    {
                        model = new FactCollectionViewModel(response.Value);
                        
                        model.IsSuccess = true;
                    }
                    else
                    {
                        model.IsSuccess = false;
                    }
                 }
                else
                {
                    model.IsSuccess = false;
                    model.IsSessionExpired = true;

                }
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                BaseViewModel model = new BaseViewModel();
                model.IsSuccess = false;
                return Json(model,JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult DeleteFact(Guid id)
        {
            BaseViewModel model = new BaseViewModel();
            try
            {
                UserFormsPrincipal principal = UserFormsPrincipal.GetPrincipal("Principal", HttpContext.Session);
                if (principal != null && principal is UserFormsPrincipal && (principal.Identity as UserFormsIdentity).User != null)
                {
                    if (id != null)
                    {

                    }
                    model.IsSuccess = false;

                    model.IsSessionExpired = false;
                }
                else
                {
                    model.IsSuccess = false;
                    model.IsSessionExpired = true;

                }

                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                return Json(model,JsonRequestBehavior.AllowGet);
            }
            //else return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public void GetFile(IFact fact)
        {
            MemoryStream workStream = new MemoryStream();
            Document document = new Document();
            PdfWriter.GetInstance(document, workStream).CloseStream = false;

            document.Open();
            document.Add(new Paragraph("Hello World"));
            document.Add(new Paragraph(DateTime.Now.ToString()));
            document.Close();

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;

            new FileStreamResult(workStream, "application/pdf");
        }
    }
}
