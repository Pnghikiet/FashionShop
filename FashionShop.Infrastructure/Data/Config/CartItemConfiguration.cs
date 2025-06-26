using FashionShop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Infrastructure.Data.Config
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantity).IsRequired();

            builder.Property(x => x.Price).HasColumnType("decimal(18,2)");

            builder.HasIndex(i => new { i.CartId, i.ProductId }).IsUnique();
        }
    }
}
