using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpochApi.DbContexts
{
    public class AccountDbContext : DbContext
    { 
        public AccountDbContext(DbContextOptions opt) : base(opt) { }
        public DbSet<Models.Account> Accounts { get; set; }
    }
}
