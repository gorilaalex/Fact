using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using ViewModel;

namespace Facturi.App_FormsAuth
{
    public class UserMembershipUser:MembershipUser
    {
        private UserViewModel _user;
        public UserMembershipUser(UserViewModel user)
        {
            _user = user;
        }
        public override string UserName
        {
            get
            {
                return this._user.Username;
            }
        }

        public UserViewModel User
        {
            get
            {
                return _user;
            }
        }
    }
}