using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasswordManager_API.Context;
using PasswordManager_API.Interfaces;

namespace PasswordManager_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupsController : ControllerBase
    {
        private readonly ILookupInterface _lookupInterface;
        public LookupsController(ILookupInterface lookupInterface)
        {
            _lookupInterface = lookupInterface;
        }

        [HttpGet("Lookups-By-Type/{typeId}")]
        public async Task<IActionResult> GetLookups([FromRoute] int typeId)
        {
            try
            {
                var response = await _lookupInterface.GetLookupItemsByTypeId(typeId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
