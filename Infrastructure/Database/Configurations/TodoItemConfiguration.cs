using Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    internal class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.ToTable(nameof(TodoItem));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnName(nameof(TodoItem.Name))
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.IsComplete)
                .HasColumnName(nameof(TodoItem.IsComplete))
                .IsRequired();

            builder.Property(x => x.Secret)
                .HasColumnName(nameof(TodoItem.Secret))
                .HasMaxLength(100)
                .IsRequired(false);
        }
    }
}
