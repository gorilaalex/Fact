using DataAccessAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OperationResponse<T> : IOperationResponse<T>
    {
        public string Message
        {
            get;
            set;
        }
        public bool IsSuccess
        {
            get;
            set;
        }
        public T Value
        {
            get;
            set;
        }
    }

    public class OperationResponse : IOperationResponse
    {
        public string Message
        {
            get;
            set;
        }
        public bool IsSuccess
        {
            get;
            set;
        }
    }
}
