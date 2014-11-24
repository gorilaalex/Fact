using DataAcces.Entities;
using DataAccessAbstraction.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Adapter
{
    public class UserAdapter
    {
        public IUser GetItem(DataTable dt)
        {
            IUser user = new User();
            try
            {
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0].Table.Columns.Contains("Id") && dt.Rows[0]["Id"] != null)
                    {
                        user.Id = new Guid(dt.Rows[0]["Id"].ToString());
                    }
                    if(dt.Rows[0].Table.Columns.Contains("Username") && dt.Rows[0]["Username"] !=null)
                    {
                        user.Username = dt.Rows[0]["Username"].ToString();
                    }
                    if(dt.Rows[0].Table.Columns.Contains("Firstname") && dt.Rows[0]["Firstname"] !=null)
                    {
                        user.FirstName = dt.Rows[0]["Firstname"].ToString();
                    }
                    if(dt.Rows[0].Table.Columns.Contains("LastName") && dt.Rows[0]["LastName"] !=null)
                    {
                        user.LastName = dt.Rows[0]["LastName"].ToString();
                    }
                    if (dt.Rows[0].Table.Columns.Contains("Password") && dt.Rows[0]["Password"] != null)
                    {
                        user.Password = dt.Rows[0]["Password"].ToString();
                    }
                    return user;
                }
                else return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
