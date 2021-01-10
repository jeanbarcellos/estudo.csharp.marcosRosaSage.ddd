using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("user");

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.Email)
                   .IsUnique();

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(128)
                .HasColumnType("varchar(128)");

            builder.Property(c => c.Email)
                .HasColumnName("email")
                .HasMaxLength(128)
                .HasColumnType("varchar(128)");

            builder.Property(c => c.CreateAt)
                .HasColumnName("create_at");

            builder.Property(c => c.UpdateAt)
                .HasColumnName("update_at");

        }
    }

}
