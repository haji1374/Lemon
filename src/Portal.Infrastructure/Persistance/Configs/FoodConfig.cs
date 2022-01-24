using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Common.Enums;
using Portal.Domain;
using Portal.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portal.Persistance.Configs
{
    public class FoodConfig : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.Property(it=> it.Id).UseHiLo();
            
            builder.HasIndex(f => f.Name).IsUnique();
            builder.Property(f => f.Name).HasMaxLength(25).IsRequired();
            builder.Property(f => f.Description).HasMaxLength(1000).IsRequired();

            builder.OwnsOne<Money>(it => it.Price);

            builder.Property(it => it.FoodType)
                   .HasColumnName("FoodType")
                   .HasConversion(it => it.Id, foodTypeId => FoodType.GetAll<FoodType>()
                                                                     .Single(it => it.Id == foodTypeId));

        }
    }
}
