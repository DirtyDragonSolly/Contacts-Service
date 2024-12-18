using Contacts.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contacts.Data.Configurations
{
    public class ContactsConfiguration : IEntityTypeConfiguration<ContactEntity>
    {

        public void Configure(EntityTypeBuilder<ContactEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsFixedLength();

            builder.Property(c => c.Number)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength();
        }
    }
}
