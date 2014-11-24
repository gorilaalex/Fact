using DataAccessAbstraction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessAbstraction.Repository
{
    public interface IFactProductUnionRepository
    {
        IOperationResponse<List<IProduct>> GetAllProductsForFact(Guid id);
    }
}
