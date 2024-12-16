using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Paradigmi.Library.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Library.Models.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(p => p.IdBook);
            builder.HasMany(p => p.Categories).WithMany(p => p.Books)
                .UsingEntity(
                "BooksCategories",
                l => l.HasOne(typeof(Category)).WithMany().HasForeignKey("NameCategory").HasPrincipalKey(nameof(Category.Name)),
                r => r.HasOne(typeof(Book)).WithMany().HasForeignKey("IdBook").HasPrincipalKey(nameof(Book.IdBook)),
                j => j.HasKey("IdBook", "NameCategory"));
            builder.Property(p => p.Name)
                .HasMaxLength(50);
            builder.Property(p => p.Author)
                .HasMaxLength(50);
            builder.Property(p => p.Editor)
            .HasMaxLength(50);

        }
    }
}
