using DataAccessAbstraction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Others;

namespace ViewModels.Product
{
    public class ProductCollectionViewModel:BaseViewModel
    {
        private List<ProductViewModel> _products;
        public ProductCollectionViewModel()
        {
            _products = new List<ProductViewModel>();
        }
        public ProductCollectionViewModel(List<IProduct> products)
        {
            _products = new List<ProductViewModel>();
            if (products != null)
            {
                foreach (IProduct x in products)
                {
                    ProductViewModel temp = new ProductViewModel(x);
                    _products.Add(temp);
                }
            }
        }
        public List<ProductViewModel> Products
        {
            get
            {
                return _products;
            }
        }

    }
}
