using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalManager.Data.Models;

namespace PersonalManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PersonalManager.Data.Models.Service> Service { get; set; }
        public DbSet<PersonalManager.Data.Models.Gateway> Gateway { get; set; }
    }
}
