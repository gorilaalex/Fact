using DataAccess;
using DataAccessAbstraction;
using DataAccessAbstraction.Entities;
using DataAccessAbstraction.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Repository
{
    public class FactRepository:IFactRepository
    {
        private string _connectionString;
        #region SqlCommands

        #endregion
        public FactRepository(string conn)
        {
            _connectionString = conn;
        }

        public IOperationResponse<IFact> Insert(IFact fact)
        {
            return new OperationResponse<IFact>(
                );
        }
        public IOperationResponse<IFact> Update(IFact fact)
        {
            return new OperationResponse<IFact>(
                );
        }
        public IOperationResponse<string> Delete(string id)
        {
            return new OperationResponse<string>(
                );
        }
        public IOperationResponse<List<IFact>> GetAllByUser(string id)
        {
            return new OperationResponse<List<IFact>>(
                );
        }
    }
}
