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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _unitOfWork.User.GetUsernameAndPassword(username, password);

            if (user == null)
            {
                throw new Exception("Kullanıcı bulunamadı !!");
            }

            return user;
        }

        public async Task<User> GetUserById(Guid id)
        {
            var user = await _unitOfWork.User.SingleOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                throw new Exception("Kullanıcı bulunamadı !!");
            }

            return user;
        }
    }
}
