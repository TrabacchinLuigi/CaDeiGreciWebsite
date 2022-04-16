using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CaDeiGreciWebsite.Data.Settings
{
    // Add-Migration -context CaDeiGreciWebsite.Data.Settings.DbContext -OutputDir Data/Settings/Migrations -Name xxx
    // remove-Migration -context CaDeiGreciWebsite.Data.Settings.DbContext

    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Opening> Openings { get; set; }
        public DbContext(DbContextOptions<DbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema($"{nameof(CaDeiGreciWebsite.Data.Settings)}");
        }
    }
}
