using brk.Core.Domain.User.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace brk.Data.SQL.User.Config
{
    internal class UserMapping : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            throw new NotImplementedException();
        }
    }
}
