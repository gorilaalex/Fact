using DataAccessAbstraction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Others;

namespace ViewModels.Facts
{
    public class FactViewModel : BaseViewModel
    {
        public FactViewModel()
        {

        }

        public Guid ID { get; set; }
        public DateTime Date { get; set; }
        public string Series { get; set; }
        public DateTime PayDate { get; set; }
        public Guid ExpeditorID { get; set; }//guy who deliver the products
        public Guid SellerId { get; set; } // company that sell
        public Guid BuyerId { get; set; } //company that buy
        public double TotalSum { get; set; }
        public double TotalTVA { get; set; }
        public string TVAType { get; set; }// la incasare sau dedus cred
        public ICompany UserCompany { get; set; }
        public ICompany BuyerCompany { get; set; }
        public IExpeditor Expeditor { get; set; }
        public List<IProduct> Products { get; set; }

        public FactViewModel(IFact fact)
        {
            this.ID = fact.Id;
            this.Date = fact.Date;
            this.Series = fact.Series;
            this.PayDate = fact.PayDate;
            this.ExpeditorID = fact.ExpeditorId;
            this.SellerId = fact.SellerId;
            this.BuyerId = fact.BuyerId;
            this.TotalSum = fact.TotalSum;
            this.TotalTVA = fact.TotalTVA;
            this.TVAType = fact.TVAType;
        }
    }
}
