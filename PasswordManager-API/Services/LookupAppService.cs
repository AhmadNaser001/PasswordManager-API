using Microsoft.EntityFrameworkCore;
using PasswordManager_API.Context;
using PasswordManager_API.DTOs.Lookup;
using PasswordManager_API.Interfaces;

namespace PasswordManager_API.Services
{
    public class LookupAppService : ILookupInterface
    {
        private readonly PasswordManagerDbContext _context;
        public LookupAppService(PasswordManagerDbContext context)
        {
            _context = context;
        }
        public async Task<List<LookupItemDTO>> GetLookupItemsByTypeId(int typeId)
        {
            var query = from item in _context.LookupItems
                        join type in _context.LookupTypes on item.LookupTypeId equals type.Id
                        where type.Id == typeId
                        select new LookupItemDTO
                        {
                            Id = item.Id,
                            Name = item.Name,
                            ParentName = type.Name
                        };
            return await query.ToListAsync();
        }
    }
}
