using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Others;

namespace ViewModels.User
{
    public class CaptchaViewModel : BaseViewModel
    {
        public string Challenge { get; set; }
        public string Response { get; set; }
    }
}
