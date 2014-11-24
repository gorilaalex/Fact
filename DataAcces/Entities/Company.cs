using DataAccessAbstraction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Entities
{
    public class Company:ICompany
    {
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
    }
}
