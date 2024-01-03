using brk.Core.Domain.List.Entities;
using brk.Core.Domain.User.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace brk.Data.SQL.List.Config
{
    internal class ListConfig : IEntityTypeConfiguration<ListModel>
    {
        public void Configure(EntityTypeBuilder<ListModel> builder)
        {
            builder.HasOne<UserModel>()
                .WithMany()
                .HasForeignKey(m => m.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
