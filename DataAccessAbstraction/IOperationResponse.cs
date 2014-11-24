using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessAbstraction
{
    public interface IOperationResponse<T>
    {
        string Message { get; set; }
        bool IsSuccess { get; set; }
        T Value { get; set; }
    }

    public interface IOperationResponse
    {
        string Message { get; set; }
        bool IsSuccess { get; set; }

    }
}
