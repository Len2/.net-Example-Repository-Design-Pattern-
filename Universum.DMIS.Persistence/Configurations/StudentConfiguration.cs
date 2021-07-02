using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Universum.DMIS.Domain.Entities;

namespace Universum.DMIS.Persistence.Configurations
{
    class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                  .HasColumnName("ID")
                  .ValueGeneratedOnAdd()
                  .IsRequired();

            builder.Property(x => x.FirstName)
                .HasColumnName("FirstName")
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasColumnName("LastName")
                .IsRequired();

            builder.Property(x => x.DateOfBirth)
                .HasColumnName("DateOfBirth")
                .IsRequired();

            builder.Property(x => x.Address)
                .HasColumnName("Address")
                .IsRequired();

            builder.ToTable("Students");
        }
    }
}
