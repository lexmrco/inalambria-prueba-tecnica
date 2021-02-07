using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Inalambria.Domain.Entities;
using System;

namespace Inalambria.Infrastructure.Mapping
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers", "Sales").HasMany<Order>(s => s.Orders)
            .WithOne(c => c.Customer);
        }
    }
}
