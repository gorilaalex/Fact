using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Others
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {
            IsSuccess = true;
        }

        public bool IsSuccess 
        { 
            get; 
            set; 
        }
        public string Message
        {
            get;
            set;
        }

        public string ReturnUrl
        {
            get;
            set;
        }

        public bool IsSessionExpired
        {
            get;
            set;
        }
    }
}