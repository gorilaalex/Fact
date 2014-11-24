using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Facturi
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region CSS files

            bundles.Add(new StyleBundle("~/bundles/boot")
               .Include("~/Content/ext/bootstrap.css")
               .Include("~/Content/ext/bootstrap-theme.css"));

            bundles.Add(new StyleBundle("~/bundles/other")
                .Include("~/Content/ext/jquery-ui-1.9.2.custom.css")
                .Include("~/Content/ext/notify.css"));


            #endregion

            #region jQuery

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/Utils/ext/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/Utils/ext/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/Utils/ext/jquery.validate*"));

            #endregion

            /*#region Modernizer

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr")
               .Include("~/Scripts/ext/modernizr-*"));

            #endregion
            */
           #region Crypto

            bundles.Add(new ScriptBundle("~/bundles/crypto")
                .Include("~/Scripts/Utils/crypto/aes.js")
                .Include("~/Scripts/Utils/crypto//core.js")
                .Include("~/Scripts/Utils/crypto/enc-base64.js")
                .Include("~/Scripts/Utils/crypto/enc-utf16.js")
                .Include("~/Scripts/Utils/crypto/md5.js")
                .Include("~/Scripts/Utils/crypto/sha3.js"));

            #endregion
            
            #region Other JS dependencies

            bundles.Add(new ScriptBundle("~/bundles/dependent")
                .Include("~/Scripts/Utils/ext/amplify.core.js")
                .Include("~/Scripts/Utils/ext/amplify.store.js")
                .Include("~/Scripts/Utils/ext/sammy.js")
                .Include("~/Scripts/Utils/ext/knockout-3.2.0.js")
                .Include("~/Scripts/Utils/ext/knockout.mapping-latest.js")
                .Include("~/Scripts/Utils/ext/modernizr-*"));

            #endregion

            #region Application common JS files

            bundles.Add(new ScriptBundle("~/bundles/common_js")
                .Include("~/Scripts/Utils/Entities.js")
                .Include("~/Scripts/Utils/utils.js")
                .Include("~/Scripts/Utils/nav-model.js")

               .Include("~/Scripts/Utils/Constants.js"));

            #endregion

            #region NoAuth JS files

            bundles.Add(new ScriptBundle("~/bundles/noauth_js")
               .Include("~/Account/login-module.js")
               .Include("~/Account/register-module.js"));

            #endregion

            #region Auth JS files

            bundles.Add(new ScriptBundle("~/bundles/auth_js")
               .Include("~/Facts/facts-definition.js")
               .Include("~/Home/profile-module.js"));

            #endregion
        }
    }
}