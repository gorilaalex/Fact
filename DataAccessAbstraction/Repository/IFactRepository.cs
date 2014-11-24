using DataAccessAbstraction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessAbstraction.Repository
{
    public interface IFactRepository
    {
        IOperationResponse<IFact> Insert(IFact fact);
        IOperationResponse<IFact> Update(IFact fact);
        IOperationResponse<string> Delete(string id);
        IOperationResponse<List<IFact>> GetAllByUser(string id);
    }
}
