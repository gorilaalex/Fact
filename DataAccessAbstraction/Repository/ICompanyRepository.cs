using DataAccessAbstraction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessAbstraction.Repository
{
    public interface ICompanyRepository
    {
        IOperationResponse<ICompany> GetCompany(Guid id);
        IOperationResponse<ICompany> Insert(ICompany company);
        IOperationResponse<ICompany> Update(ICompany company);
        IOperationResponse<string> Delete(string id); // not implemented
    }
}
