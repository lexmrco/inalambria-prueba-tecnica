using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Inalambria.Domain.Entities;
using System;

namespace Inalambria.Infrastructure.Mapping
{
    public class OrderDetailsMap : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails", "Sales").HasKey(x => new { x.OrderId, x.ProductId });
            builder.HasOne<Product>(s => s.Product);
        }
    }
}
