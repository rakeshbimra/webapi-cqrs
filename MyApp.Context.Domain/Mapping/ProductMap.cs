using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApp.Context.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Context.Domain.Mapping
{
    public class ProductMap
    {
        public ProductMap(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);
            entityBuilder.Property(e => e.Price)
                .IsRequired();
            entityBuilder.Property(e => e.Description)
                .HasMaxLength(500);

        }
    }
}
