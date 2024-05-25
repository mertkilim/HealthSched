using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthSched.Models.Models.Abstract;

namespace HealthSched.Models.EntityConfigs.Abstract
{
    public abstract class BaseConfig<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.CreatedDate).HasDefaultValue(DateTime.UtcNow.AddHours(3));
            builder.Property(p=> p.isDeleted).HasDefaultValue(false);
        }
    }
}
