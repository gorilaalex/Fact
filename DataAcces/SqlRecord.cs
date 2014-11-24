using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SqlRecord<T>
    {
        private readonly T source;
        private readonly List<SqlParameter> parameters = new List<SqlParameter>();

        public SqlRecord(T source)
        {
            this.source = source;
        }

        public SqlRecord<T> Set<TValue>(Expression<Func<T, TValue>> expression,string name="")
        {
            var property = GetPropertyInfo(expression);
            var getValue = expression.Compile();
            if(!String.IsNullOrWhiteSpace(name)) parameters.Add(new SqlParameter("@" + name, getValue(source)));
            else parameters.Add(new SqlParameter("@" + property.Name, getValue(source)));
            return this;
        }

    
        public SqlParameter[] Parameters()
        {
            return parameters.ToArray();
        }

        private static PropertyInfo GetPropertyInfo<TValue>(Expression<Func<T, TValue>> expression)
        {
            var member = (MemberExpression)expression.Body;
            return member.Member as PropertyInfo;
        }
    }
}
