using DataAccessAbstraction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Unions
{
    public class FactProductUnionViewModel
    {
        public int Id { get; set; }
        public Guid FactId { get; set; }
        public Guid ProductId { get; set; }

        public FactProductUnionViewModel()
        {
        }

        public FactProductUnionViewModel(IFactProductUnion fpunion)
        {
            this.Id = fpunion.Id;
            this.ProductId = fpunion.ProductId;
            this.FactId = fpunion.FactId;
        }
    }
}
