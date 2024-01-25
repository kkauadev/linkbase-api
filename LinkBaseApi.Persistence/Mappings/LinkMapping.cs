using LinkBaseApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkBaseApi.Persistence.Mappings
{
	public class LinkMapping : IEntityTypeConfiguration<Link>
	{
		public void Configure(EntityTypeBuilder<Link> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Title).IsRequired();
			builder.Property(x => x.Url).IsRequired();

			builder.HasOne<Folder>()
				.WithMany(x => x.Links)
				.HasForeignKey(x => x.FolderId);

			builder.ToTable("Links");
		}
	}
}
