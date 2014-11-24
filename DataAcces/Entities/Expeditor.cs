using DataAccessAbstraction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Entities
{
    public class Expeditor:IExpeditor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IdentityCard { get; set; }
        public string Car { get; set; }
        public string Email { get; set; }
        public DateTime ExpeditionDate { get; set; }
        public Guid UserId { get; set; }
    }
}
