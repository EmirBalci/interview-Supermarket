using Supermarket.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Core.Services
{
    public interface IUserService
    {
        Task<User> Login(string username, string password);
        Task<User> GetUserById(Guid id);
    }
}
