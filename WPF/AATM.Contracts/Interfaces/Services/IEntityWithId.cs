using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AATM.Contracts.Interfaces.Services
{
    public interface IEntityWithId
    {
        int IdNo { get; set; }
    }
}