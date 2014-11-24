using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessAbstraction.Entities
{
    public interface IExpeditor
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string IdentityCard { get; set; }
        string Car { get; set; }
        string Email { get; set; }
        DateTime ExpeditionDate { get; set; }
        Guid UserId { get; set; }
    }
}
