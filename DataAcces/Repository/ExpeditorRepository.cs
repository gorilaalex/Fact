using DataAccessAbstraction.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Repository
{
    public class ExpeditorRepository//:IExpeditorRepository
    {
        private string _connectionString;
        #region SqlCommands

        #endregion
        public ExpeditorRepository(string conn)
        {
            _connectionString = conn;
        }
    }
}
