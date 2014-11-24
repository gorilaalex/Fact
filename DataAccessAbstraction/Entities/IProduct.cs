using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessAbstraction.Entities
{
    public interface IProduct
    {
        Guid ID { get; set; }
        string Name { get; set; }
        double Price { get; set; }
        int Quantity { get; set; }
        string MonetaryUnit { get; set; }
    }
}
