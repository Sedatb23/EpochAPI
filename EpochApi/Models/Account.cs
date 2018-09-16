using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using EpochApi.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EpochApi.Models
{
    [Table("account")]
    public class Account 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Email { get; set; }

        public string Password { get; set; }

        public bool Enabled { get; set; }

        public string IP { get; set; }
    }
}
