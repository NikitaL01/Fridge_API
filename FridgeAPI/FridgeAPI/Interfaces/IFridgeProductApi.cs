using System;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using RestEase;

namespace FridgeAPI.Interfaces;

[Header("FridgeProduct-Agent", "RestEase")]
public interface IFridgeProductApi
{
    [Get("api/fridges/{fridgeId}/products")]
    [Head("api/fridges/{fridgeId}/products")]
    Task<IActionResult> GetProductsForFridge([Path] Guid fridgeId);

    [Get("api/fridges/{fridgeId}/products/{id}")]
    Task<IActionResult> GetProductForFridge([Path] Guid fridgeId, [Path] Guid id);

    [Post("api/fridges/{fridgeId}/products/{id}")]
    Task<IActionResult> CreateProductForFridge([Path] Guid fridgeId, [Path] Guid id,
        [Body] FridgeProductForCreationDto fridgeProductForCreationDto);

    [Delete("api/fridgeProducts/{fridgeProductId}")]
    Task<IActionResult> DeleteProductForFridge([Path] Guid fridgeProductId);

    [Put("api/fridgeProducts/{fridgeProductId}")]
    Task<IActionResult> UpdateProductForFridge([Path] Guid fridgeProductId);
}