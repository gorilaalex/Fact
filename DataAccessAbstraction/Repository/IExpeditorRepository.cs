using DataAccessAbstraction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessAbstraction.Repository
{
    public interface IExpeditorRepository
    {
        IOperationResponse<IExpeditor> Insert(IExpeditor expeditor);
        IOperationResponse<IExpeditor> Update(IExpeditor expeditor);
        IOperationResponse<string> Delete(string id);
    }
}
