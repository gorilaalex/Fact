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
    public class CompanyAdapter
    {
        public ICompany GetItem(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    ICompany company = new Company();
                    if (dt.Rows[0].Table.Columns.Contains("Id") && dt.Rows[0]["Id"] != null)
                    {
                        company.Id = new Guid(dt.Rows[0]["Id"].ToString());
                    }
                    if (dt.Rows[0].Table.Columns.Contains("ContractorName") && dt.Rows[0]["ContractorName"] != null)
                    {
                        company.ContractorName = dt.Rows[0]["ContractorName"].ToString();
                    }
                    if (dt.Rows[0].Table.Columns.Contains("CIF") && dt.Rows[0]["CIF"] != null)
                    {
                        company.CIF = dt.Rows[0]["CIF"].ToString();
                    }
                    if (dt.Rows[0].Table.Columns.Contains("CUI") && dt.Rows[0]["CUI"] != null)
                    {
                        company.CUI = dt.Rows[0]["CUI"].ToString();
                    }
                    if (dt.Rows[0].Table.Columns.Contains("SerialNumber") && dt.Rows[0]["SerialNumber"] != null)
                    {
                        company.SerialNumber = dt.Rows[0]["SerialNumber"].ToString();
                    }
                    if (dt.Rows[0].Table.Columns.Contains("IBAN") && dt.Rows[0]["IBAN"] != null)
                    {
                        company.IBAN = dt.Rows[0]["IBAN"].ToString();
                    }
                    if (dt.Rows[0].Table.Columns.Contains("Bank") && dt.Rows[0]["Bank"] != null)
                    {
                        company.Bank = dt.Rows[0]["Bank"].ToString();
                    }
                    if (dt.Rows[0].Table.Columns.Contains("Email") && dt.Rows[0]["Email"] != null)
                    {
                        company.Email = dt.Rows[0]["Email"].ToString();
                    }
                    if (dt.Rows[0].Table.Columns.Contains("Telephone") && dt.Rows[0]["Telephone"] != null)
                    {
                        company.Telephone = dt.Rows[0]["Telephone"].ToString();
                    }
                    if (dt.Rows[0].Table.Columns.Contains("SocialCapital") && dt.Rows[0]["SocialCapital"] != null)
                    {
                        company.SocialCapital = Int64.Parse(dt.Rows[0]["SocialCapital"].ToString());
                    }
                    if (dt.Rows[0].Table.Columns.Contains("TVARate") && dt.Rows[0]["TVARate"] != null)
                    {
                        company.TVARate = Int64.Parse(dt.Rows[0]["TVARate"].ToString());
                    }
                    if (dt.Rows[0].Table.Columns.Contains("UserId") && dt.Rows[0]["UserId"] != null)
                    {
                        company.UserId = new Guid(dt.Rows[0]["UserId"].ToString());
                    }
                    return company;
                }
                else return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<ICompany> GetItems(DataTable dt)
        {
            try
            {
                List<ICompany> list = new List<ICompany>();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ICompany company = new Company();
                        if (dt.Rows[i].Table.Columns.Contains("Id") && dt.Rows[i]["Id"] != null)
                        {
                            company.Id = new Guid(dt.Rows[i]["Id"].ToString());
                        }
                        if (dt.Rows[i].Table.Columns.Contains("ContractorName") && dt.Rows[i]["ContractorName"] != null)
                        {
                            company.ContractorName = dt.Rows[i]["ContractorName"].ToString();
                        }
                        if (dt.Rows[i].Table.Columns.Contains("CIF") && dt.Rows[i]["CIF"] != null)
                        {
                            company.CIF = dt.Rows[i]["CIF"].ToString();
                        }
                        if (dt.Rows[i].Table.Columns.Contains("CUI") && dt.Rows[i]["CUI"] != null)
                        {
                            company.CUI = dt.Rows[i]["CUI"].ToString();
                        }
                        if (dt.Rows[i].Table.Columns.Contains("SerialNumber") && dt.Rows[i]["SerialNumber"] != null)
                        {
                            company.SerialNumber = dt.Rows[i]["SerialNumber"].ToString();
                        }
                        if (dt.Rows[i].Table.Columns.Contains("IBAN") && dt.Rows[i]["IBAN"] != null)
                        {
                            company.IBAN = dt.Rows[i]["IBAN"].ToString();
                        }
                        if (dt.Rows[i].Table.Columns.Contains("Bank") && dt.Rows[i]["Bank"] != null)
                        {
                            company.Bank = dt.Rows[i]["Bank"].ToString();
                        }
                        if (dt.Rows[i].Table.Columns.Contains("Email") && dt.Rows[i]["Email"] != null)
                        {
                            company.Email = dt.Rows[i]["Email"].ToString();
                        }
                        if (dt.Rows[i].Table.Columns.Contains("Telephone") && dt.Rows[i]["Telephone"] != null)
                        {
                            company.Telephone = dt.Rows[i]["Telephone"].ToString();
                        }
                        if (dt.Rows[i].Table.Columns.Contains("SocialCapital") && dt.Rows[i]["SocialCapital"] != null)
                        {
                            company.SocialCapital = Int64.Parse(dt.Rows[i]["SocialCapital"].ToString());
                        }
                        if (dt.Rows[i].Table.Columns.Contains("TVARate") && dt.Rows[i]["TVARate"] != null)
                        {
                            company.TVARate = Int64.Parse(dt.Rows[i]["TVARate"].ToString());
                        }
                        list.Add(company);
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
