using Supermarket.Core;
using Supermarket.Core.Domains;
using Supermarket.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Services
{
    public class SalesService : ISalesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SalesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Sales> Create(Sales sales)
        {
            await _unitOfWork.Sales.AddAsync(sales);
            var isAdded = await _unitOfWork.CommitAsync();

            if (isAdded < 1)
            {
                throw new Exception("Satış gerçekleşmedi !!");
            }

            return sales;
        }

        public Task<IEnumerable<Sales>> GetAll()
        {
            var saleses = _unitOfWork.Sales.GetAllAsync();

            if (saleses == null)
            {
                throw new Exception("Hiç satış yapılmamıştır !!");
            }

            return saleses;
        }

        public async Task<Sales> GetById(Guid id)
        {
            var sales = await _unitOfWork.Sales.GetByIdAsync(id);

            if (sales == null)
            {
                throw new Exception("Böyle bir satış yok !!");
            }

            return sales;
        }
    }
}
