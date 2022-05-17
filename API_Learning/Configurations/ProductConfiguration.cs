using API_Learning.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Learning.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(40).IsRequired();
            builder.Property(p => p.Price).HasColumnType("money").IsRequired();
            builder.Property(p => p.DiscountPrice).HasColumnType("money");
            //builder.Property(p => p.CreatedAt).HasDefaultValue(DateTime.UtcNow.AddHours(4));
            //builder.Property(p => p.DeletedAt).HasDefaultValue(DateTime.UtcNow.AddHours(4));
            //builder.Property(p => p.UpdatedAt).HasDefaultValue(DateTime.UtcNow.AddHours(4));

        }
    }
}
