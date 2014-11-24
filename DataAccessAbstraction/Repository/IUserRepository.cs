using DataAccessAbstraction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessAbstraction.Repository
{
    public interface IUserRepository
    {
        IOperationResponse<IUser> GetLogin(string username,string password);
        IOperationResponse<IUser> Insert(IUser user);
        IOperationResponse<IUser> Update(IUser user);
        IOperationResponse<string> Delete(string id);
        IOperationResponse<bool> CheckIfUserExists(string username);
    }
}
