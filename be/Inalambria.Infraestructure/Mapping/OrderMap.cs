using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Inalambria.Domain.Entities;
using System;

namespace Inalambria.Infrastructure.Mapping
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "Sales").HasOne<Customer>(s => s.Customer)
            .WithMany(c => c.Orders);
            builder.HasMany(x => x.OrderDetails).WithOne(x => x.Order);
        }
    }
}
