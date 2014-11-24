using DataAccessAbstraction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Others;

namespace ViewModels.Product
{
    public class ProductViewModel:BaseViewModel
    {
        #region fields
        public Guid ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string UM { get; set; }
        #endregion
        public ProductViewModel()
        {
        }
        public ProductViewModel(IProduct product)
        {
            this.ID = product.ID;
            this.Name = product.Name;
            this.Price = product.Price;
            this.Quantity = product.Quantity;
            this.UM = product.MonetaryUnit;
        }
    }
}
