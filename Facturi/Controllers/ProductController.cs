using DataAccessAbstraction.Entities;
using Facturi.App_FormsAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Facturi.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult GetProductsForFact()
        {
            UserFormsPrincipal principal = UserFormsPrincipal.GetPrincipal("Principal", HttpContext.Session);
            if (principal != null && principal is UserFormsPrincipal && (principal.Identity as UserFormsIdentity).User != null)
            {
                return View();
            }
            else return RedirectToAction("Login", "Account");
        }
        public ActionResult AddProduct(IProduct product)
        {
            UserFormsPrincipal principal = UserFormsPrincipal.GetPrincipal("Principal", HttpContext.Session);
            if (principal != null && principal is UserFormsPrincipal && (principal.Identity as UserFormsIdentity).User != null)
            {
                return View();
            }
            else return RedirectToAction("Login", "Account");
        }
        public ActionResult DeleteProduct(Guid Id)
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
