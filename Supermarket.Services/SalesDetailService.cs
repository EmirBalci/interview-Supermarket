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
    public class SalesDetailService : ISalesDetailService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SalesDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SalesDetail> Create(SalesDetail salesDetail)
        {
            await _unitOfWork.SalesDetail.AddAsync(salesDetail);
            var isAdded = await _unitOfWork.CommitAsync();

            if (isAdded < 1)
            {
                throw new Exception("Satış detayı eklenemedi !!");
            }

            return salesDetail;
        }

        public async Task RemoveAllByProductId(Guid id)
        {
            var details = await _unitOfWork.SalesDetail.GetAllAsync(x => x.ProductId == id);

            if (details == null)
            {
                throw new Exception("Satış detayları bulunamadı !!");
            }

            _unitOfWork.SalesDetail.RemoveRange(details);

            var isDeleted = await _unitOfWork.CommitAsync();

            if (isDeleted < 1)
            {
                throw new Exception("Satış detayları silinemedi !!");
            }
        }
    }
}
