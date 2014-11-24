using Facturi.App_FormsAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

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

        
        public ActionResult GetFacts()
        {
            return View();
        }

        public ActionResult AddFact()
        {
            return View();
        }

        public ActionResult DeleteFact()
        {
            return View();
        }

    }
}
