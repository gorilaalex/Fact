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
    public class ExpeditorAdapter
    {
        public IExpeditor GetItem(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    IExpeditor expeditor = new Expeditor();
                    if (dt.Rows[0].Table.Columns.Contains("Id") && dt.Rows[0]["Id"] != null)
                    {
                        expeditor.Id = new Guid(dt.Rows[0]["Id"].ToString());
                    }
                    if(dt.Rows[0].Table.Columns.Contains("Name") && dt.Rows[0]["Name"] !=null)
                    {
                        expeditor.Name = dt.Rows[0]["Name"].ToString();
                    }
                    if (dt.Rows[0].Table.Columns.Contains("IdentityCard") && dt.Rows[0]["IdentityCard"] != null)
                    {
                        expeditor.IdentityCard = dt.Rows[0]["IdentityCard"].ToString();
                    }
                    if (dt.Rows[0].Table.Columns.Contains("Car") && dt.Rows[0]["Car"] != null)
                    {
                        expeditor.Car = dt.Rows[0]["Car"].ToString();
                    }
                    if (dt.Rows[0].Table.Columns.Contains("Email") && dt.Rows[0]["Email"] != null)
                    {
                        expeditor.Email = dt.Rows[0]["Email"].ToString();
                    }
                    if (dt.Rows[0].Table.Columns.Contains("FactId") && dt.Rows[0]["FactId"] != null)
                    {
                        expeditor.FactId = new Guid(dt.Rows[0]["FactId"].ToString());
                    }
                    if (dt.Rows[0].Table.Columns.Contains("ExpeditionDate") && dt.Rows[0]["ExpeditionDate"] != null)
                    {
                        //expeditor.ExpeditionDate = dt.Rows[0]["ExpeditionDate"].ToString();
                    }
                    return expeditor;
                }
                else return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<IExpeditor> GetItems(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<IExpeditor> list = new List<IExpeditor>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        IExpeditor expeditor = new Expeditor();

                        list.Add(expeditor);
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
