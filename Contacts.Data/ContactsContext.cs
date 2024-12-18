using Contacts.Core.Models.Entities;
using Contacts.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Data
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options) : base (options)
        {            
        }

        public DbSet<ContactEntity> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().ToTable("contacts");
        }
    }
}
