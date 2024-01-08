using LinkBaseApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkBaseApi.Persistence.Mappings
{
	public class UserMapping : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(x => x.Id);

			builder.HasIndex(x => x.Email).IsUnique();
			builder.HasIndex(x => x.Username).IsUnique();

			builder.Property(u => u.Username).IsRequired();
			builder.Property(x => x.Name).IsRequired();
			builder.Property(x => x.Email).IsRequired();
			builder.Property(x => x.Password).IsRequired();
			builder.Property(u => u.Created).HasDefaultValueSql("getdate()");

			builder.ToTable("Users");
		}
	}
}
