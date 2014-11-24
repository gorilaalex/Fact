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
    public class FactAdapter
    {
        public IFact GetItem(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    IFact fact = new Fact();
                    if (dt.Rows[0].Table.Columns.Contains("Id") && dt.Rows[0]["Id"] != null)
                    {
                        fact.ID = new Guid(dt.Rows[0]["Id"].ToString());
                    }
                    if (dt.Rows[0].Table.Columns.Contains("Series") && dt.Rows[0]["Series"] != null)
                    {
                        fact.Series = dt.Rows[0]["Series"].ToString();
                    }
                    if (dt.Rows[0].Table.Columns.Contains("Date") && dt.Rows[0]["Date"] != null)
                    {
                        //fact.Date = new DateTime(dt.Rows[0]["Date"].ToString().);
                    }
                    if (dt.Rows[0].Table.Columns.Contains("PayDate") && dt.Rows[0]["PayDate"] != null)
                    {
                        //fact.PayDate = dt.Rows[0]["PayDate"].ToString();
                    }
                    if (dt.Rows[0].Table.Columns.Contains("TotalSum") && dt.Rows[0]["TotalSum"] != null)
                    {
                        fact.TotalSum = Int64.Parse(dt.Rows[0]["TotalSum"].ToString());
                    }
                    if (dt.Rows[0].Table.Columns.Contains("TotalTVA") && dt.Rows[0]["TotalTVA"] != null)
                    {
                        fact.TotalTVA = Int64.Parse(dt.Rows[0]["TotalTVA"].ToString());
                    }
                    if (dt.Rows[0].Table.Columns.Contains("TVAType") && dt.Rows[0]["TVAType"] != null)
                    {
                        fact.TVAType = dt.Rows[0]["TVAType"].ToString();
                    }
                    if (dt.Rows[0].Table.Columns.Contains("BuyerId") && dt.Rows[0]["BuyerId"] != null)
                    {
                        fact.BuyerId = new Guid(dt.Rows[0]["BuyerId"].ToString());
                    }
                    if (dt.Rows[0].Table.Columns.Contains("SellerId") && dt.Rows[0]["SellerId"] != null)
                    {
                        fact.SellerId = new Guid(dt.Rows[0]["SellerId"].ToString());
                    }
                    if (dt.Rows[0].Table.Columns.Contains("ExpeditorId") && dt.Rows[0]["ExpeditorId"] != null)
                    {
                        fact.ExpeditorID = new Guid(dt.Rows[0]["ExpeditorId"].ToString());
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
        public List<IFact> GetItems(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<IFact> list = new List<IFact>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        IFact fact = new Fact();
                        //fact = GetItem(dt.Rows[i]);
                        list.Add(fact);
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
