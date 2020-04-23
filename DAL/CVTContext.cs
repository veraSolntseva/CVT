using DAL.DbObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class CVTContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<ContactInfo> Contacts { get; set; }


        public CVTContext(DbContextOptions<CVTContext> options) : base(options) { }
    }
}
