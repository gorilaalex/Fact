using DataAcces.Entities;
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
    public class FactProductUnionRepository:IFactProductUnionRepository
    {
        private string _connectionString;
        #region SqlCommands
        private const string GET_ALL_PRODUCTS_FOR_FACT = @"SELECT * FROM [dbo].[FactProductUnion] where [FactId] like @factId INNER JOIN...";
        #endregion
        public FactProductUnionRepository(string conn)
        {
            _connectionString = conn;
        }

        public IOperationResponse<List<IProduct>> GetAllProductsForFact(Guid id)
        {
            try
            {
                List<IProduct> products = new List<IProduct>();
                var record = new SqlRecord<IFact>(new Fact() {
                    Id = id
            });


                return new OperationResponse<List<IProduct>>()
                {
                    
                };
            }
            catch (Exception ex)
            {
                return new OperationResponse<List<IProduct>>()
                {
                    IsSuccess=false,
                    Message = ex.Message
                };
            }
            

        }
    }
}
