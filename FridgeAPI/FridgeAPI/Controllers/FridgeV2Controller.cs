using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
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
            //var fridges = await _repositoryManager.Fridge.GetAllFridgesAsync(trackChanges: false);

            //return Ok(fridges);

            Thread.Sleep(5);
            return Ok(new List<Fridge>
            {
                new Fridge
                {
                    Id = Guid.NewGuid(),
                    Name = "AAA",
                    OwnerName = "aaa"
                },
                new Fridge
                {
                    Id = Guid.NewGuid(),
                    Name = "BBB",
                    OwnerName = "bbb"
                },
                new Fridge
                {
                    Id = Guid.NewGuid(),
                    Name = "CCC",
                    OwnerName = "ccc"
                },
            });
        }

    }
}
