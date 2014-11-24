using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Facturi.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult ChangePasswordView()
        {
            if (Request.IsAuthenticated)
            {
                Response.AppendHeader("X-AUTH", "true");
            }
            else
            {
                Response.AppendHeader("X-AUTH", "false");
            }
            return PartialView("ChangePasswordView");
        }

    }
}
