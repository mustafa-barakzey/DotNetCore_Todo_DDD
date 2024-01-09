
using brk.Core.Domain.List.Entities;

namespace brk.Core.Domain.List.Data
{
    public interface IListQueryService
    {
        Task<ListModel?> GetAsync(long userId, long id);
        Task<List<ListModel>> GetByUserIdAsync(long userId);
        Task<ListModel?> GetListAsync(long listOwnerId, long listId);
    }
}
