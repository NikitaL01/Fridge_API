using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Filters.ActionFilters;
using Microsoft.AspNetCore.Mvc;

namespace FridgeAPI.Controllers
{
    [Route("api/fridges/{fridgeId}/products")]
    [ApiController]
    public class FridgeProductController : ControllerBase
    {
        private readonly ILoggerManager _loggerManager;

        private readonly IRepositoryManager _repositoryManager;

        private readonly IMapper _mapper;

        public FridgeProductController(ILoggerManager loggerManager,
            IRepositoryManager repositoryManager, IMapper mapper)
        {
            _loggerManager = loggerManager;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        public async Task<IActionResult> GetProductsForFridge(Guid fridgeId)
        {
            var fridge = await _repositoryManager.Fridge.GetFridgeAsync(fridgeId,
                trackChanges: false);

            if (fridge == null)
            {
                _loggerManager.LogInfo($"Fridge with id: {fridgeId} doesn't exist in the" +
                    $" database.");
                return NotFound();
            }

            var fridgeProductsFromDb = await _repositoryManager.FridgeProduct
                .GetFridgeProductsAsync(trackChanges: false);

            if (fridgeProductsFromDb == null)
            {
                _loggerManager.LogInfo($"FridgeProducts for Fridge with id: {fridgeId} doesn't" +
                    $" exist in the database.");
                return NotFound();
            }

            var products = await _repositoryManager.Product
                .GetByIdsAsync(fridgeProductsFromDb.Select(fp => fp.ProductId),
                    false);

            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);

            return Ok(productsDto);
        }

        [HttpGet("{id}", Name = "GetProductForFridge")]
        [ServiceFilter(typeof(ValidateProductForFridgeExistsAttribute))]
        public Task<IActionResult> GetProductForFridge(Guid fridgeId, Guid id)
        {
            var productDb = HttpContext.Items["product"] as Product;

            var product = _mapper.Map<ProductDto>(productDb);
            return Task.FromResult<IActionResult>(Ok(product));
        }

        [HttpPost("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateProductForFridgeExistsAttribute))]
        public async Task<IActionResult> CreateProductForFridge(Guid fridgeId, Guid id,
            [FromBody] FridgeProductForCreationDto fridgeProductForCreationDto)
        {
            var product = HttpContext.Items["product"] as Product;

            var fridgeProductEntity = _mapper.Map<FridgeProduct>(fridgeProductForCreationDto);
            _repositoryManager.FridgeProduct.CreateFridgeProduct(fridgeId, id, fridgeProductEntity);
            await _repositoryManager.SaveAsync();

            var productToReturn = _mapper.Map<ProductDto>(product);
            return CreatedAtRoute("GetProductForFridge", new { fridgeId,
                id = productToReturn.Id }, productToReturn);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateProductForFridgeExistsAttribute))]
        public async Task<IActionResult> DeleteProductForFridge(Guid fridgeId, Guid id,
            [FromBody] FridgeProductForDeleteDto fridgeProductForDeleteDto)
        {
            var fridgeProductEntity = HttpContext.Items["fridgeProduct"] as FridgeProduct;
            
            _repositoryManager.FridgeProduct.DeleteFridgeProduct(fridgeProductEntity!);
            await _repositoryManager.SaveAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateProductForFridgeExistsAttribute))]
        public async Task<IActionResult> UpdateFridgeModelForFridge(Guid fridgeId, Guid id,
            [FromBody] FridgeProductForUpdateDto fridgeProductForUpdateDto)
        {
            var fridgeProductEntity = HttpContext.Items["fridgeProduct"] as FridgeProduct;

            _mapper.Map(fridgeProductForUpdateDto, fridgeProductEntity);
            await _repositoryManager.SaveAsync();

            return NoContent();
        }
    }
}
