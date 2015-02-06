using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ViewModel.Others;

namespace Facturi.Controllers
{
    public class ErrorController : BaseController
    {
        //
        // GET: /Error/

        public ActionResult NotFound()
        {
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            var viewModel = new ErrorModel()
            {
                Exception = Server.GetLastError(),
                HttpStatusCode = Response.StatusCode
            };
            return View(viewModel);
        }

        public ActionResult ServerError()
        {
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var viewModel = new ErrorModel()
            {
                Exception = Server.GetLastError(),
                HttpStatusCode = Response.StatusCode
            };
            return View(viewModel);
        }

        public ActionResult AccessDenied()
        {
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            var viewModel = new ErrorModel()
            {
                Exception = Server.GetLastError(),
                HttpStatusCode = Response.StatusCode
            };
            return View(viewModel);
        }

        public ActionResult Unauthorized()
        {
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            var viewModel = new ErrorModel()
            {
                Exception = Server.GetLastError(),
                HttpStatusCode = Response.StatusCode
            };
            return View(viewModel);
        }

    }
}
