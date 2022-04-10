using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Data
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext(DbContextOptions<PhoneBookContext> options) : base(options)
        {

        }
        public DbSet<Area> Areas { get; set; }
        public DbSet<PhoneBookRecord> PhoneBookRecords { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneBookRecord>().ToTable("PhoneBookRecord");
            modelBuilder.Entity<Area>().ToTable("Area");
        }
    }
}
