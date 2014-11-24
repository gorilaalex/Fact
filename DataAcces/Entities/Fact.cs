using DataAccessAbstraction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Entities
{
    public class Fact:IFact
    {
        public Guid ID { get; set; }
        public DateTime Date { get; set; }
        public string Series { get; set; }
        public DateTime PayDate { get; set; }
        public Guid ExpeditorID { get; set; }
        public Guid SellerId { get; set; }
        public Guid BuyerId { get; set; }
        public double TotalSum { get; set; }
        public double TotalTVA { get; set; }
        public string TVAType { get; set; }
    }
}
