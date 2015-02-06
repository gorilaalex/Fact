using DataAccessAbstraction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Others;

namespace ViewModel
{
    public class UserViewModel:BaseViewModel
    {
        public UserViewModel()
        {

        }
        public UserViewModel(IUser user)
        {
            this.Id = user.Id;
            this.Username = user.Username;
            this.Password = user.Password;
            this.LastName = user.LastName;
            this.FirstName = user.FirstName;
        }

       

        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        /*add automapper
        public void Build()
        {
            Mapper.CreateMap<IUser, UserViewModel>();
            Mapper.CreateMap<UserViewModel, IUser>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id));
        }
        */
    }
}
