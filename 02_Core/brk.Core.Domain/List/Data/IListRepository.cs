using brk.Core.Domain.List.Entities;
using brk.Core.Domain.List.ValueObjects;
using brk.Framework.Base.Data;
using brk.Framework.Base.ValueObjects;

namespace brk.Core.Domain.List.Data
{
    public interface IListRepository : IBaseRepository<ListModel, long>
    {
        Task<bool> IsExistAsync(ListOwnerId listOwnerId, Title title);
    }
}
