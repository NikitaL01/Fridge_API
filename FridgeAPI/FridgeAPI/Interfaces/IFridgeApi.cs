using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using FridgeAPI.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using RestEase;

namespace FridgeAPI.Interfaces;

[Header("Fridge-Agent", "RestEase")]
public interface IFridgeApi
{
    [Get("api/fridges")]
    Task<IActionResult> GetFridges();

    [Get("api/fridges/{id}")]
    Task<IActionResult> GetFridge([Path] string id);

    [Post("api/fridges")]
    Task<IActionResult> CreateFridge([Body] FridgeForCreationDto fridge);

    [Get("api/fridges/collection/{ids}")]
    Task<IActionResult> GetFridgeCollection([Path]
        [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids);

    [Post("api/fridges/collection")]
    Task<IActionResult> CreateFridgeCollection([Body] IEnumerable<FridgeForCreationDto> fridgeCollection);

    [Delete("api/fridges/{id}")]
    Task<IActionResult> DeleteFridge([Path] Guid id);

    [Put("api/fridges/{id}")]
    Task<IActionResult> UpdateFridge([Path] Guid id, [Body] FridgeForUpdateDto fridge);

    [Options("api/fridges")]
    IActionResult GetFridgesOptions();
}