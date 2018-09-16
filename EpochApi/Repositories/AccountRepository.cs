using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpochApi.Repositories
{
    public class AccountRepository : BaseRepository<Models.Account>
    {
        private readonly DbContexts.AccountDbContext _context;

        public AccountRepository(DbContexts.AccountDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> SaveAccount(Models.Account account)
        {
            var data = _context.Accounts.Add(account);
            return await _context.SaveChangesAsync() > 0;
        }

        public bool AccountExists(string username)
        {
            int count = _context.Accounts.Where(x => x.Name == username).Count();
            return count > 0 ;
        }
    }
}
