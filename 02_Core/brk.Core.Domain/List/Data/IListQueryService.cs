
using brk.Core.Domain.List.Entities;

namespace brk.Core.Domain.List.Data
{
    public interface IListQueryService
    {
        Task<List<ListModel>> GetByUserIdAsync(long userId);
    }
}
