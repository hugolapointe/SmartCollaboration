using Core.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations {

    public class StudentConfiguration : IEntityTypeConfiguration<Student> {

        public void Configure(EntityTypeBuilder<Student> builder) {
            builder.Property(s => s.DA).IsRequired();
            builder.Property(s => s.FirstName).IsRequired();
            builder.Property(s => s.LastName).IsRequired();
        }
    }
}
