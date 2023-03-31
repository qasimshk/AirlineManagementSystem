using database.migration.app.Domain.Menu;
using database.migration.app.Domain.Menu.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace database.migration.app.Persistance.Configurations
{
    public class MenuEntityTypeConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menus");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasConversion(
                id => id.Value,
                value => MenuId.Create(value));

            builder.Property(x => x.Name)
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .HasMaxLength(100);

            builder.OwnsOne(x => x.AverageRating);

            builder.Property(x => x.ReferenceNumber)
                .HasDefaultValue("FORMAT((NEXT VALUE FOR GeneratedStringSequence), 'a#')");

            builder.OwnsMany(x => x.Sections, sb =>
            {
                sb.ToTable("MenuSections");

                sb.HasKey("Id", "MenuId");

                sb.WithOwner().HasForeignKey("MenuId");

                sb.Property(x => x.Id)
                    .HasColumnName("MenuSectionId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => MenuSectionId.Create(value));

                sb.Property(x => x.Name)
                    .HasMaxLength(100);

                sb.Property(x => x.Description)
                    .HasMaxLength(100);

                sb.OwnsMany(s => s.Items, ib =>
                {
                    ib.ToTable("MenuItems");

                    ib.WithOwner().HasForeignKey("MenuSectionId", "MenuId");

                    ib.HasKey("Id", "MenuSectionId", "MenuId");

                    ib.Property(i => i.Id)
                       .HasColumnName("MenuItemId")
                       .ValueGeneratedNever()
                       .HasConversion(
                            id => id.Value,
                            value => MenuItemId.Create(value));

                    ib.Property(x => x.Name)
                        .HasMaxLength(100);

                    ib.Property(x => x.Description)
                        .HasMaxLength(100);
                });

                sb.Navigation(s => s.Items).Metadata.SetField("_items");
                sb.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
            });

            builder.Metadata.FindNavigation(nameof(Menu.Sections))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
