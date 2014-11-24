using DataAccessAbstraction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessAbstraction.Repository
{
    public interface IProductRepository
    {
        IOperationResponse<IProduct> Insert(IProduct product);
        IOperationResponse<IProduct> Update(IProduct product);
        IOperationResponse<string> Delete(string id);
    }
}
