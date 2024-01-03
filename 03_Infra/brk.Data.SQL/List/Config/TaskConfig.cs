using brk.Core.Domain.List.Entities;
using brk.Core.Domain.TaskList.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace brk.Data.SQL.List.Config
{
    internal class TaskConfig : IEntityTypeConfiguration<TaskModel>
    {
        public void Configure(EntityTypeBuilder<TaskModel> builder)
        {
            builder.ToTable("Tasks");

            builder.HasOne<ListModel>()
                .WithMany(m=>m.Tasks)
                .HasForeignKey(m => m.ListId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
