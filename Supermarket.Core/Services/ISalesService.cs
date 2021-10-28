using Supermarket.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Core.Services
{
    public interface ISalesService
    {
        Task<IEnumerable<Sales>> GetAll();
        Task<Sales> GetById(Guid id);
        Task<Sales> Create(Sales sales);
    }
}
