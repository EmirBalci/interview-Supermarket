using Microsoft.EntityFrameworkCore;
using Supermarket.Core.Domains;
using Supermarket.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(SupermarketContext context)
            : base(context)
        { }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await SupermarketDbContext.Users
                .ToListAsync();
        }

        public Task<User> GetWithUserByIdAsync(Guid id)
        {
            return SupermarketDbContext.Users
               .SingleOrDefaultAsync(a => a.Id == id);
        }

        public Task<User> GetUsernameAndPassword(string username, string password)
        {
            return SupermarketDbContext.Users.SingleOrDefaultAsync(x => x.Username == username && x.Password == password);
        }

        private SupermarketContext SupermarketDbContext
        {
            get { return Context as SupermarketContext; }
        }
    }
}
