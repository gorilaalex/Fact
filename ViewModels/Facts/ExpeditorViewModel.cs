using DataAccessAbstraction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Facts
{
    public class ExpeditorViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IdentityCard { get; set; }
        public string Car { get; set; }
        public string Email { get; set; }
        public DateTime ExpeditionDate { get; set; }
        public Guid UserId { get; set; }

        public ExpeditorViewModel()
        {
        }

        public ExpeditorViewModel(IExpeditor expeditor)
        {
            this.Id = expeditor.Id;
            this.Name = expeditor.Name;
            this.IdentityCard = expeditor.IdentityCard;
            this.Car = expeditor.Car;
            this.Email = expeditor.Email;
            this.ExpeditionDate = expeditor.ExpeditionDate;
            this.UserId = expeditor.UserId;
        }
    }
}
