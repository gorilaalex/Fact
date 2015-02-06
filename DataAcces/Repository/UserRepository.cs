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
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Repository
{
    public class UserRepository:IUserRepository
    {
        private string _connectionString;

        #region SqlCommands
        private const string GET_LOGIN = @"SELECT * FROM [User] WHERE [Username] LIKE @username AND [Password] LIKE @password";
        private const string CHECK_USER = @"SELECT * FROM [User] WHERE [Username] LIKE @username";
        private const string INSERT_USER = @"DECLARE @idN uniqueidentifier
                                                SET @idN = NEWID()

INSERT INTO [User] ([Id],[Username],[FirstName],[LastName],[CompanyId],[Password])VALUES (@idN,@username,@firstname, 
           @lastname,null,@password)
select @idN ";
        private const string UPDATE_USER = @"Update  [dbo].[User]
           Set [FirstName] = @firstname
           ,[LastName] = @lastname
           ,[Password] = @password
            where [Id]=@id";
        #endregion

        public UserRepository(string connection)
        {
            _connectionString = connection;
        }

        public IOperationResponse<IUser> GetLogin(string username, string password)
        {
            try
            {
                var record = new SqlRecord<IUser> (new User(){
                        Username = username,
                        Password = password
                    })
                    .Set(x =>x.Username)
                    .Set(x => x.Password);
                IUser user = new User(){
                        Username = username,
                        Password = password
                    };
                
                DataSet ds = new DataSet();
                SqlHelper.FillDataset(_connectionString, CommandType.Text, GET_LOGIN, ds, new string[] { "User" },record.Parameters());
                if (ds.Tables.Count > 0)
                {
                    UserAdapter adapter = new UserAdapter();
                    user = adapter.GetItem(ds.Tables[0]);
                }
                return new OperationResponse<IUser>()
                {
                    IsSuccess = true,
                    Value = user
                };
            }
            catch (Exception ex)
            {
                return new OperationResponse<IUser>()
                {
                     Message = ex.Message,
                     IsSuccess = false,
                     Value = null
                };
            }
        }
        public IOperationResponse<IUser> Insert(IUser user)
        {
            try
            {

                var record = new SqlRecord<IUser>(user)
                    .Set(x => x.Username)
                    .Set(x => x.Password)
                    .Set(x=>x.FirstName)
                    .Set(x=>x.LastName);

                Guid result = (Guid)SqlHelper.ExecuteScalar(_connectionString, CommandType.Text, INSERT_USER, record.Parameters());

                Guid temp;
                if (result != null && Guid.TryParse(result.ToString(), out temp))
                {
                    user.Id = temp;
                    return new OperationResponse<IUser>()
                    {
                        IsSuccess = true,
                        Value = user
                    };
                }
          else
          {
              return new OperationResponse<IUser>()
              {
                  IsSuccess = false,
                  Value = null
              };
          }     
            }
            catch (Exception ex)
            {
                return new OperationResponse<IUser>()
                {
                    Message = ex.Message,
                    IsSuccess = false,
                    Value = null
                };
            }
        }
        public IOperationResponse<IUser> Update(IUser user)
        {
            try
            {
                var record = new SqlRecord<IUser>(user)
                .Set(x => x.Id)
                    .Set(x => x.Username)
                    .Set(x => x.Password)
                    .Set(x => x.FirstName)
                    .Set(x => x.LastName);

                // NonQueryResults
                int result = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, UPDATE_USER, record.Parameters());

                return new OperationResponse<IUser>()
                {
                    IsSuccess = true,
                    Value = user
                };
            }
            catch (Exception ex)
            {
                return new OperationResponse<IUser>()
                {
                    Message = ex.Message,
                    IsSuccess = false,
                    Value = null
                };
            }
        }
        public IOperationResponse<string> Delete(string id)
        {
            return new OperationResponse<string>(
                );
        }


        public IOperationResponse<bool> CheckIfUserExists(string username)
        {
            try
            {
                var record = new SqlRecord<IUser>(new User()
                {
                    Username = username
                })
                    .Set(x => x.Username);
                IUser user = new User()
                {
                    Username = username
                };

                DataSet ds = new DataSet();
                 SqlHelper.FillDataset(_connectionString, CommandType.Text, CHECK_USER, ds, new []{"User"} ,record.Parameters());
                
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        return new OperationResponse<bool>()
                        {
                            IsSuccess = false,
                            Message = "An user with this email address is already registred."
                        };
                    }
                else
                {

                    return new OperationResponse<bool>()
                    {
                        IsSuccess = true
                       
                    };
                }
            }
            catch (Exception ex)
            {
                return new OperationResponse<bool>()
                {
                    Message = ex.Message,
                    IsSuccess = false,
                };
            }
        }
    }
}
