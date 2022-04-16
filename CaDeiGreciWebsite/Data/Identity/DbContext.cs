using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CaDeiGreciWebsite.Data.Identity
{
    // add-Migration -Context CaDeiGreciWebsite.Data.Identity.DbContext -OutputDir Data\Identity\Migrations
    // remove-Migration -Context CaDeiGreciWebsite.Data.Identity.DbContext
    public class DbContext : Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext
    {
        public DbContext(DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        protected DbContext() : base() { }
    }
}
