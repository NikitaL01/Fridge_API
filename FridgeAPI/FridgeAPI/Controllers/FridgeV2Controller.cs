using Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FridgeAPI.Controllers
{
    [ApiVersion("2.0", Deprecated = true)]
    [Route("api/fridges")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v2")]
    public class FridgeV2Controller : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;

        public FridgeV2Controller(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetFridges()
        {
            var fridges = await _repositoryManager.Fridge.GetAllFridgesAsync(trackChanges: false);

            return Ok(fridges);
        }

    }
}
