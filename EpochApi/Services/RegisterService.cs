using EpochApi.DbContexts;
using EpochApi.Models;
using EpochApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpochApi.Services
{
    public class RegisterService
    {
        private AccountDbContext _context { get; }

        private AccountRepository _accountRepository;
         
        public RegisterService(DbContext context)
        {
            _context = context as AccountDbContext;
            _accountRepository = new Repositories.AccountRepository(_context);
        }

        public bool AccountExists(string username)
        { 
            return _accountRepository.Find(x => x.Name == username).Count() > 0;
        }
        public async Task<bool> SaveAccount(Models.Account account)
        {
            var data = _context.Accounts.Add(account);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
