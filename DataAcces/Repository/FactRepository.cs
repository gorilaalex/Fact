using DataAcces.Adapter;
using DataAcces.Entities;
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
    public class FactRepository:IFactRepository
    {
        private string _connectionString;
        #region SqlCommands
        private const string INSERT_FACTS = @"DECLARE @idN uniqueidentifier
                                                SET @idN = NEWID()
INSERT INTO [Fact] ([Id],[Date],[Series],[ExpeditorId],[PayDate],[SellerId],[BuyerId],[TotalSum],[TotalTVA])VALUES (@idN,@date,@series, 
           @expeditorId,null,@sellerId, @buyerId,@totalSum,@totalTVA)
select @idN";
        private const string GET_FACTS = @"Select * from [dbo].[Fact] where [SellerId] = @sellerId";
        private const string DELETE_FACT = @"DELETE FROM [dbo].[Fact] WHERE [Id]=@id";
        #endregion
        public FactRepository(string conn)
        {
            _connectionString = conn;
        }

        public IOperationResponse<IFact> Insert(IFact fact)
        {
            try
            {

                var record = new SqlRecord<IFact>(fact)
                    .Set(x => x.Id)
                    .Set(x => x.Date)
                    .Set(x => x.Series)
                    .Set(x => x.ExpeditorId)
                    .Set(x => x.BuyerId)
                    .Set(x => x.SellerId)
                    .Set(x => x.TotalSum)
                    .Set(x => x.TotalTVA)
                    ;

                Guid result = (Guid)SqlHelper.ExecuteScalar(_connectionString, CommandType.Text, INSERT_FACTS, record.Parameters());

                Guid temp;
                if (result != null && Guid.TryParse(result.ToString(), out temp))
                {
                    fact.Id = temp;
                    return new OperationResponse<IFact>()
                    {
                        IsSuccess = true,
                        Value = fact
                    };
                }
                else
                {
                    return new OperationResponse<IFact>()
                    {
                        IsSuccess = false,
                        Value = null
                    };
                }
            }
            catch (Exception ex)
            {
                return new OperationResponse<IFact>()
                {
                    Message = ex.Message,
                    IsSuccess = false,
                    Value = null
                };
            }

        }
        public IOperationResponse<IFact> Update(IFact fact)
        {
            return new OperationResponse<IFact>(
                );
        }
        public IOperationResponse<string> Delete(Guid id)
        {
            try
            {
                var record = new SqlRecord<IFact>(new Fact()
                {
                    Id = id,
                })
                  .Set(x => x.Id);

                int result = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, DELETE_FACT, record.Parameters());

                return new OperationResponse<string>()
                {
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new OperationResponse<string>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
        public IOperationResponse<List<IFact>> GetAllByUser(Guid id)
        {
            try
            {
                List<IFact> union = new List<IFact>();
                DataSet ds = new DataSet();

                    IFact fact = new Fact()
                    {
                        SellerId = id
                    };
                    var record = new SqlRecord<IFact>(fact);
                    record
                        .Set(x => x.SellerId);
                    SqlHelper.FillDataset(_connectionString, CommandType.Text, GET_FACTS, ds, new string[] { "Admins" }, record.Parameters());
             
                
                if (ds.Tables.Count > 0 && ds.Tables.Count ==1)
                {
                    FactAdapter adapter = new FactAdapter();
                    union = adapter.GetItems(ds.Tables[0]);

                }
                IOperationResponse<List<IFact>> retVal = new OperationResponse<List<IFact>>()
                {
                    IsSuccess = true,
                    Value = union
                };

                return retVal;
            }
            catch (Exception ex)
            {
                return new OperationResponse<List<IFact>>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
