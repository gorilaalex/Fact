using DataAccessAbstraction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Others;

namespace ViewModels.Facts
{
    public class FactCollectionViewModel : BaseViewModel
    {
        public List<FactViewModel> Facts;
        public FactCollectionViewModel()
        {
            Facts = new List<FactViewModel>();
        }
        public FactCollectionViewModel(List<IFact> facts)
        {
            Facts = new List<FactViewModel>();
            if (facts != null)
            {
                foreach (IFact fact in facts)
                {
                    FactViewModel factVM = new FactViewModel(fact);
                    Facts.Add(factVM);
                }
            }
        }
    }
}
