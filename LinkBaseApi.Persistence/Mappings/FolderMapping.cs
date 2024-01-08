using LinkBaseApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkBaseApi.Persistence.Mappings
{
	public class FolderMapping : IEntityTypeConfiguration<Folder>
	{
		public void Configure(EntityTypeBuilder<Folder> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Created).HasDefaultValueSql("getdate()");
			builder.Property(x => x.Name).IsRequired();

			builder.HasOne<User>()
				.WithMany(x => x.Folders)
				.HasForeignKey(x => x.UserId);

			builder.ToTable("Folders");
		}
	}
}
