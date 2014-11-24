using DataAccessAbstraction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Entities
{
    public class FactProductUnion:IFactProductUnion
    {
        public int Id { get; set; }
        public Guid FactId { get; set; }
        public Guid ProductId { get; set; }
    }
}
