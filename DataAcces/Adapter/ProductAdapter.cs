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
    public class ProductAdapter
    {
        public IProduct GetItem(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    IProduct product = new Product();
                    if (dt.Rows[0].Table.Columns.Contains("Id") && dt.Rows[0]["Id"] != null)
                    {
                        product.ID = new Guid(dt.Rows[0]["Id"].ToString());
                    }
                    if (dt.Rows[0].Table.Columns.Contains("Name") && dt.Rows[0]["Name"] != null)
                    {
                        product.Name = dt.Rows[0]["Name"].ToString();
                    }
                    if (dt.Rows[0].Table.Columns.Contains("Price") && dt.Rows[0]["Price"] != null)
                    {
                        product.Price = Int32.Parse(dt.Rows[0]["Price"].ToString());
                    }
                    if (dt.Rows[0].Table.Columns.Contains("Quantity") && dt.Rows[0]["Quantity"] != null)
                    {
                        product.Quantity = Int32.Parse(dt.Rows[0]["Quantity"].ToString());
                    }
                    if (dt.Rows[0].Table.Columns.Contains("MonetaryUnit") && dt.Rows[0]["MonetaryUnit"] != null)
                    {
                        product.MonetaryUnit = dt.Rows[0]["MonetaryUnit"].ToString();
                    }
                    return product;
                }
                else return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<IProduct> GetItems(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<IProduct> list = new List<IProduct>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        IProduct product = new Product();
                        if (dt.Rows[i].Table.Columns.Contains("Id") && dt.Rows[i]["Id"] != null)
                        {
                            product.ID = new Guid(dt.Rows[i]["Id"].ToString());
                        }
                        if (dt.Rows[i].Table.Columns.Contains("Name") && dt.Rows[i]["Name"] != null)
                        {
                            product.Name = dt.Rows[i]["Name"].ToString();
                        }
                        if (dt.Rows[i].Table.Columns.Contains("Price") && dt.Rows[i]["Price"] != null)
                        {
                            product.Price = Int32.Parse(dt.Rows[i]["Price"].ToString());
                        }
                        if (dt.Rows[i].Table.Columns.Contains("Quantity") && dt.Rows[i]["Quantity"] != null)
                        {
                            product.Quantity = Int32.Parse(dt.Rows[i]["Quantity"].ToString());
                        }
                        if (dt.Rows[i].Table.Columns.Contains("MonetaryUnit") && dt.Rows[i]["MonetaryUnit"] != null)
                        {
                            product.MonetaryUnit = dt.Rows[i]["MonetaryUnit"].ToString();
                        }
                        list.Add(product);
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
