using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessAbstraction.Entities
{
    public interface IFactProductUnion
    {
        int Id {get;set;}
        Guid FactId { get; set; }
        Guid ProductId { get; set; }
    }
}
