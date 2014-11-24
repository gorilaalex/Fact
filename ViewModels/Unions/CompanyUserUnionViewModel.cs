using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.Others;
using ViewModels.User;

namespace ViewModels.Unions
{
    public class CompanyUserUnionViewModel:BaseViewModel
    {
        private UserViewModel _userVM { get; set; }
        private CompanyViewModel _companyVM { get; set; }

        public CompanyUserUnionViewModel()
        {
        }

        public CompanyUserUnionViewModel(UserViewModel uVM,CompanyViewModel cVM)
        {
            _userVM = uVM;
            _companyVM = cVM;
        }

        public UserViewModel UserVM
        {
            get
            {
                return _userVM;
            }
        }

        public CompanyViewModel CompanyVM
        {
            get 
            {
                return _companyVM;
            }
        }
    }
}
