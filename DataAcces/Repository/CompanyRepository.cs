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
    public class CompanyRepository:ICompanyRepository
    {
        private string _connectionString;
        #region SqlCommands
        private const string GET_COMPANY_FOR_USER = @"Select * from [dbo].[Company] where [UserId] like @userId";
        private const string INSERT_COMPANY = @"DECLARE @idN uniqueidentifier
                                                SET @idN = NEWID()
                                                INSERT INTO [dbo].[Company] ([Id],[ContractorName],[CIF],[CUI],[SerialNumber],[IBAN],[Bank],[Email],[Telephone],[SocialCapital],[TVARate]) VALUES (@idN,@contractorName,@cif,@cui,@serialNumber,@iban,@bank,@email,@telephone,@socialCapital,@tvaRate)
                                                select @idN";
        private const string UPDATE_COMPANY = @"UPDATE [dbo].[Company] SET [ContractorName] = @ContractorName,[CIF] = @CIF,[CUI] = @CUI,[SerialNumber] = @SerialNumber, [IBAN] = @IBAN, [Bank]= @Bank, [Email]=@Email,
                                             [Telephone]=@Telephone, [SocialCapital]=@SocialCapital, [TVARate] = @TVARate WHERE [Id]=@id";
        #endregion
        public CompanyRepository(string conn)
        {
            _connectionString = conn;
        }

        public IOperationResponse<ICompany> GetCompany(Guid id)
        {
            try
            {
                var record = new SqlRecord<ICompany>(new Company() {
                UserId=id})
                .Set(x=>x.UserId);
                ICompany company = new Company();

                DataSet ds = new DataSet();
                SqlHelper.FillDataset(_connectionString, CommandType.Text, GET_COMPANY_FOR_USER, ds, new string[] { "Company" }, record.Parameters());
                if (ds.Tables.Count > 0)
                {
                    CompanyAdapter adapter = new CompanyAdapter();
                    company = adapter.GetItem(ds.Tables[0]);
                }

                return new OperationResponse<ICompany>() { 
                Value= company,
                IsSuccess=true
                };
            }
            catch(Exception ex)
            {
                return new OperationResponse<ICompany>() { 
                    Message=ex.Message,
                    Value=null,
                    IsSuccess=false
                };
            }
        }
        public IOperationResponse<ICompany> Insert(ICompany company)
        {
            try
            {
                var record = new SqlRecord<ICompany>(company)
                 .Set(x => x.IBAN)
                 .Set(x => x.Email)
                 .Set(x => x.Bank)
                 .Set(x => x.CIF)
                 .Set(x => x.ContractorName)
                 .Set(x => x.CUI)
                 .Set(x => x.SerialNumber)
                 .Set(x => x.SocialCapital)
                 .Set(x => x.Telephone)
                 .Set(x => x.TVARate)
                 .Set(x => x.UserId);

                Guid result = (Guid)SqlHelper.ExecuteScalar(_connectionString, CommandType.Text, INSERT_COMPANY, record.Parameters());
                Guid temp;
                if (result != null && Guid.TryParse(result.ToString(), out temp))
                {
                    company.Id = temp;
                }
                else
                {
                    return new OperationResponse<ICompany>() {
                        Message = "Error inserting a company.",
                        Value = null,
                        IsSuccess = false
                    }; 
                }

                return new OperationResponse<ICompany>() {
                    IsSuccess = true,
                    Value = company
                };
            }
            catch (Exception ex)
            {
                return new OperationResponse<ICompany>() { Message=ex.Message,
                Value=null,
                IsSuccess=false};
            }
            
        }
        public IOperationResponse<ICompany> Update(ICompany company)
        {
            try
            {
                var record = new SqlRecord<ICompany>(company)
                .Set(x => x.Id)
                .Set(x => x.IBAN)
                .Set(x => x.Email)
                .Set(x => x.Bank)
                .Set(x => x.CIF)
                .Set(x => x.ContractorName)
                .Set(x => x.CUI)
                .Set(x => x.SerialNumber)
                .Set(x => x.SocialCapital)
                .Set(x => x.Telephone)
                .Set(x => x.TVARate)
                .Set(x => x.UserId);


                Int32 result = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, UPDATE_COMPANY,record.Parameters());
                if (result != 0)
                {
                    return new OperationResponse<ICompany>()
                    {
                        IsSuccess = true,
                        Value = company
                    };
                }
                else
                {
                    return new OperationResponse<ICompany>()
                    {
                        IsSuccess=false,
                        Message ="Something is wrong with the query."
                    };
                }
            }
            catch (Exception ex)
            {
                return new OperationResponse<ICompany>() { 
                    IsSuccess = false,
                    Message=ex.ToString()
                };
            }
            
        }
        public IOperationResponse<string> Delete(string id)
        {
            return new OperationResponse<string>() { };
        }

    }
}
