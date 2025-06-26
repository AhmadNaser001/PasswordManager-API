using PasswordManager_API.DTOs.Lookup;

namespace PasswordManager_API.Interfaces
{
    public interface ILookupInterface
    {
        Task<List<LookupItemDTO>> GetLookupItemsByTypeId(int typeId);
    }
}
