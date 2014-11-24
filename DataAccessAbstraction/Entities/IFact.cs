using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessAbstraction.Entities
{
    public interface IFact
    {
        Guid ID { get; set; }
        DateTime Date { get; set; }
        string Series { get; set; }
        DateTime PayDate { get; set; }
        Guid ExpeditorID { get; set; }//guy who deliver the products
        Guid SellerId { get; set; } // company that sell
        Guid BuyerId { get; set; } //company that buy
        double TotalSum { get; set; }
        double TotalTVA { get; set; }
        string TVAType { get; set; }// la incasare sau dedus cred
    }
}
