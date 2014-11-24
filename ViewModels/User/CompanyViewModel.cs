using DataAccessAbstraction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Others;

namespace ViewModels.User
{
    public class CompanyViewModel:BaseViewModel
    {
        #region fields
        public Guid Id { get; set; }
        public string ContractorName { get; set; }
        public string SerialNumber { get; set; }
        public string CIF { get; set; }
        public string CUI { get; set; }
        public string IBAN { get; set; }
        public string Bank { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public long SocialCapital { get; set; }
        public long TVARate { get; set; }
        public Guid UserId { get; set; }
        #endregion

        public CompanyViewModel()
        {
        }

        public CompanyViewModel(ICompany company)
        {
            this.Id = company.Id;
            this.ContractorName = company.ContractorName;
            this.SerialNumber = company.SerialNumber;
            this.CIF = company.CIF;
            this.CUI = company.CUI;
            this.IBAN = company.IBAN;
            this.Bank = company.Bank;
            this.Email = company.Email;
            this.Telephone = company.Telephone;
            this.SocialCapital = company.SocialCapital;
            this.TVARate = company.TVARate;
            this.UserId = company.UserId;
        }
    }
}
