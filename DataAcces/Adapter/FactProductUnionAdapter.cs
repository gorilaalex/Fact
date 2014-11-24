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
    public class FactProductUnionAdapter
    {
        public IFactProductUnion GetItem(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    IFactProductUnion fact = new FactProductUnion();
                    if (dt.Rows[0].Table.Columns.Contains("Id") && dt.Rows[0]["Id"] != null)
                    {
                        fact.Id = Int32.Parse(dt.Rows[0]["Id"].ToString());
                    }
                    if (dt.Rows[0].Table.Columns.Contains("FactId") && dt.Rows[0]["FactId"] != null)
                    {
                        fact.FactId = new Guid(dt.Rows[0]["FactId"].ToString());
                    }
                    if (dt.Rows[0].Table.Columns.Contains("ProductId") && dt.Rows[0]["ProductId"] != null)
                    {
                        fact.ProductId = new Guid(dt.Rows[0]["ProductId"].ToString());
                    }
                    return fact;
                }
                else return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<IFactProductUnion> GetItems(DataTable dt)
        {
            List<IFactProductUnion> list = new List<IFactProductUnion>();
            try
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        IFactProductUnion factUnion = new FactProductUnion();
                        if (dt.Rows[i].Table.Columns.Contains("Id") && dt.Rows[i]["Id"] != null)
                        {
                            factUnion.Id = Int32.Parse(dt.Rows[i]["Id"].ToString());
                        }
                        if (dt.Rows[i].Table.Columns.Contains("FactId") && dt.Rows[i]["FactId"] != null)
                        {
                            factUnion.FactId = new Guid(dt.Rows[i]["FactId"].ToString());
                        }
                        if (dt.Rows[i].Table.Columns.Contains("ProductId") && dt.Rows[i]["ProductId"] != null)
                        {
                            factUnion.ProductId = new Guid(dt.Rows[i]["ProductId"].ToString());
                        }
                        list.Add(factUnion);
                    }
                    return list;
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
