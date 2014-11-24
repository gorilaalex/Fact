using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using ViewModel;

namespace Facturi.App_FormsAuth
{
    public class UserFormsIdentity:IIdentity
    {
        private UserViewModel _user;
        private string _authentificationType;

        public UserFormsIdentity(string authentificationType, UserViewModel user)
        {
            this._user = user;
            this._authentificationType = authentificationType;
        }

        public UserViewModel User
        {
            get
            {
                return _user;
            }
        }

        public string AuthenticationType
        {
            get
            {
                return _authentificationType;
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return true;
            }
        }

        public string Name
        {
            get
            {
                return _user.Username;
            }
        }


    }
}