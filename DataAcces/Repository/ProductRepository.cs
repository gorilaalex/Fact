using DataAccess;
using DataAccessAbstraction;
using DataAccessAbstraction.Entities;
using DataAccessAbstraction.Repository;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Repository
{
    public class ProductRepository:IProductRepository
    {
        private string _connectionString;
        #region SqlCommands
        private const string INSERT_PRODUCT = @"insert into [dbo].[Product] ([Id],[Name],[Price],[Quantity],[MonetaryUnit]) values (NEWID(),@name,@price,@quantity,@monetaryunit)";
        #endregion
        public ProductRepository(string conn)
        {
            _connectionString = conn;
        }

        public IOperationResponse<IProduct> Insert(IProduct product)
        {
            try
            {
                var record = new SqlRecord<IProduct>(product)
                .Set(x => x.Name)
                .Set(x => x.Price)
                .Set(x => x.Quantity)
                .Set(x => x.MonetaryUnit);

                Guid result = (Guid)SqlHelper.ExecuteScalar(_connectionString, CommandType.Text, INSERT_PRODUCT, record.Parameters());
                Guid temp;
                if (result != null && Guid.TryParse(result.ToString(), out temp))
                {
                    product.ID = temp;
                }
                else
                {
                    return new OperationResponse<IProduct>()
                    {
                        Message = "Error inserting a PRODUCT.",
                        Value = null,
                        IsSuccess = false
                    };
                }

                return new OperationResponse<IProduct>()
                {
                    Value=product,
                    IsSuccess=true
                   
                };
            }
            catch (Exception ex)
            {
                return new OperationResponse<IProduct>() { 
                Message=ex.Message,
                Value=null
                };
            }
        }
        public IOperationResponse<IProduct> Update(IProduct product)
        {
            return new OperationResponse<IProduct>(
                );
        }
        public IOperationResponse<string> Delete(string id)
        {
            return new OperationResponse<string>(
                );
        }
        
    }
}
