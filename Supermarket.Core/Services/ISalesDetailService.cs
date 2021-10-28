using Supermarket.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Core.Services
{
    public interface ISalesDetailService
    {
        Task<SalesDetail> Create(SalesDetail salesDetail);
        Task RemoveAllByProductId(Guid id);
    }
}
