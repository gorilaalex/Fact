using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessAbstraction.Entities
{
    public interface ICompany
    {
        Guid Id { get; set; }
        string ContractorName { get; set; }
        string SerialNumber { get; set; }
        string CIF { get; set; }
        string CUI { get; set; }
        string IBAN { get; set; }
        string Bank { get; set; }
        string Email { get; set; }
        string Telephone { get; set; }
        long SocialCapital { get; set; }
        long TVARate { get; set; }
        Guid UserId { get; set; }
    }
}
