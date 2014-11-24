using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using ViewModel;

namespace Facturi.App_FormsAuth
{
    public class UserFormsPrincipal:IPrincipal
    {
        private UserFormsIdentity _identity;

        public UserFormsPrincipal(UserViewModel user,string authentificationType)
        {
            _identity = new UserFormsIdentity(authentificationType,user);
        }

        public bool IsInRole(string role)
        {
            return Roles.IsUserInRole(role);
        }

        public IIdentity Identity
        {
            get
            {
                return _identity;
            }
        }

        public UserViewModel UserIdentity
        {
            get
            {
                return _identity.User;
            }
        }

        internal static void CachePrincipalInSession(string sessionKey, UserMembershipUser user, HttpSessionStateBase sessionBase)
        {
            UserFormsPrincipal principal = new UserFormsPrincipal(user.User,"Forms");
            sessionBase[sessionKey] = principal;
        }

        internal static void UpdatePrincipalInSession(string sessionKey, UserFormsPrincipal principal, HttpSessionStateBase sessionBase)
        {
            sessionBase[sessionKey] = principal;
        }

        internal static void RemovePrincipalFromSession(string sessionKey, HttpSessionStateBase sessionBase)
        {
            sessionBase[sessionKey] = null;
        }

        internal static UserFormsPrincipal GetPrincipal(string sessionKey, HttpSessionStateBase sessionBase)
        {
            UserFormsPrincipal userPrincipal = sessionBase[sessionKey] as UserFormsPrincipal;
            return userPrincipal;
        }
    }
}