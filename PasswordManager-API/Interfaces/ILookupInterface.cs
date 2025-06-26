using PasswordManager_API.DTOs;

namespace PasswordManager_API.Interfaces
{
    public interface ILookupInterface
    {
        Task<List<LookupItemDTO>> GetLookupItemsByTypeId(int typeId);
    }
}
