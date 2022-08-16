﻿using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using Filters.ActionFilters;
using FridgeAPI.Utility;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FridgeAPI.Controllers
{
    [Route("api/fridges/{fridgeId}/fridge_models")]
    [ApiController]
    public class FridgeModelController : ControllerBase
    {
        private readonly ILoggerManager _loggerManager;

        private readonly IRepositoryManager _repositoryManager;

        private readonly IMapper _mapper;

        private readonly FridgeModelLinks _fridgeModelLinks;

        public FridgeModelController(ILoggerManager loggerManager,
            IRepositoryManager repositoryManager, IMapper mapper,
            FridgeModelLinks fridgeModelLinks)
        {
            _loggerManager = loggerManager;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _fridgeModelLinks = fridgeModelLinks;
        }

        [HttpGet]
        [HttpHead]
        [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
        public async Task<IActionResult> GetFridgeModelsForFridge(Guid fridgeId, [FromQuery]
        FridgeModelParameters fridgeModelParameters)
        {
            if (!fridgeModelParameters.ValideYearRange)
            {
                return BadRequest("Max year can't be less than min year.");
            }

            var fridge = await _repositoryManager.Fridge.GetFridgeAsync(fridgeId,
                trackChanges: false);

            if (fridge == null)
            {
                _loggerManager.LogInfo($"Fridge with id: {fridgeId} doesn't exist in the" +
                    $" database.");
                return NotFound();
            }

            var fridgeModelsFromDb = await _repositoryManager.FridgeModel
                .GetFridgeModelsAsync(fridgeId, fridgeModelParameters, trackChanges: false);

            if (fridgeModelsFromDb == null)
            {
                _loggerManager.LogInfo($"FridgeModels for Fridge with id: {fridgeId} doesn't" +
                    $" exist in the database.");
                return NotFound();
            }

            Response.Headers.Add("X-Pagination",
                JsonConvert.SerializeObject(fridgeModelsFromDb.MetaData));

            var fridgeModelsDto = _mapper.Map<IEnumerable<FridgeModelDto>>(fridgeModelsFromDb);

            var links = _fridgeModelLinks.TryGenerateLinks(fridgeModelsDto,
                fridgeModelParameters.Fields, fridgeId, HttpContext);

            return links.HasLinks ? Ok(links.LinkedEntities) : Ok(links.ShapedEntities);
        }

        [HttpGet("{id}", Name = "GetFridgeModelForFridge")]
        [ServiceFilter(typeof(ValidateFridgeModelForFridgeExistsAttribute))]
        public async Task<IActionResult> GetFridgeModelForFridge(Guid fridgeId, Guid id)
        {
            //var fridge = await _repositoryManager.Fridge.GetFridgeAsync(fridgeId,
            //    trackChanges: false);

            //if (fridge == null)
            //{
            //    _loggerManager.LogInfo($"Fridge with id: {fridgeId} doesn't exist" +
            //        $" in the database.");
            //    return NotFound();
            //}

            //var fridgeModelDb = await _repositoryManager.FridgeModel.GetFridgeModelAsync(fridgeId,
            //    id, trackChanges: false);

            //if (fridgeModelDb == null)
            //{
            //    _loggerManager.LogInfo($"FridgeModel with id: {id} doesn't exist in the database.");
            //    return NotFound();
            //}

            var fridgeModelDb = HttpContext.Items["fridgeModel"] as FridgeModel;

            var fridgeModel = _mapper.Map<FridgeModelDto>(fridgeModelDb);
            return Ok(fridgeModel);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateFridgeModelForFridge(Guid fridgeId,
            [FromBody] FridgeModelForCreationDto fridgeModelForUpdateDto)
        {
            //if (fridgeModel == null)
            //{
            //    _loggerManager.LogError("FridgeModelForCreationDto object sent from client" +
            //        " is null.");
            //    return BadRequest("FridgeModelForCreationDto object is null");
            //}

            //if (!ModelState.IsValid)
            //{
            //    _loggerManager.LogError("Invalid model state for the FridgeModelForCreationDto" +
            //        " object.");
            //    return UnprocessableEntity(ModelState);
            //}

            var fridge = await _repositoryManager.Fridge.GetFridgeAsync(fridgeId,
                trackChanges: false);

            if (fridge == null)
            {
                _loggerManager.LogInfo($"Fridge with id: {fridgeId} doesn't exist in the" +
                    $" database.");
                return NotFound();
            }

            var fridgeModelEntity = _mapper.Map<FridgeModel>(fridgeModelForUpdateDto);

            _repositoryManager.FridgeModel.CreateFridgeModel(fridgeId, fridgeModelEntity);
            await _repositoryManager.SaveAsync();

            var fridgeModelToReturn = _mapper.Map<FridgeModelDto>(fridgeModelEntity);
            return CreatedAtRoute("GetFridgeModelForFridge", new { fridgeId,
                id = fridgeModelToReturn.Id }, fridgeModelToReturn);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateFridgeModelForFridgeExistsAttribute))]
        public async Task<IActionResult> DeleteFridgeModelForFridge(Guid fridgeId, Guid id)
        {
            //var fridge = await _repositoryManager.Fridge.GetFridgeAsync(fridgeId,
            //    trackChanges: false);

            //if (fridge == null)
            //{
            //    _loggerManager.LogInfo($"Fridge with id: {fridgeId} doesn't exist in the" +
            //        $" database.");
            //    return NotFound();
            //}

            //var fridgeModelForFridge = await _repositoryManager.FridgeModel
            //    .GetFridgeModelAsync(fridgeId, id,trackChanges: false);

            //if (fridgeModelForFridge == null)
            //{
            //    _loggerManager.LogInfo($"FridgeModel with id: {id} doesn't exist" +
            //        $" in the database.");
            //    return NotFound();
            //}

            var fridgeModelForFridge = HttpContext.Items["fridgeModel"] as FridgeModel;

            _repositoryManager.FridgeModel.DeleteFridgeModel(fridgeModelForFridge);
            await _repositoryManager.SaveAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateFridgeModelForFridgeExistsAttribute))]
        public async Task<IActionResult> UpdateFridgeModelForFridge(Guid fridgeId, Guid id,
            [FromBody] FridgeModelForUpdateDto fridgeModelForUpdateDto)
        {
            //if (fridgeModel == null)
            //{
            //    _loggerManager.LogError("FridgeModelForUpdateDto object sent from client is null.");
            //    return BadRequest("FridgeModelForUpdateDto object is null");
            //}

            //if (!ModelState.IsValid)
            //{
            //    _loggerManager.LogError("Invalid model state for the FridgeModelForUpdateDto object");
            //    return UnprocessableEntity(ModelState);
            //}

            //var fridge = await _repositoryManager.Fridge.GetFridgeAsync(fridgeId,
            //    trackChanges: false);

            //if (fridge == null)
            //{
            //    _loggerManager.LogInfo($"Fridge with id: {fridgeId} doesn't exist" +
            //        $" in the database.");
            //    return NotFound();
            //}

            //var fridgeModelEntity = await _repositoryManager.FridgeModel
            //    .GetFridgeModelAsync(fridgeId, id, trackChanges:true);

            //if (fridgeModelEntity == null)
            //{
            //    _loggerManager.LogInfo($"FridgeModel with id: {id} doesn't exist" +
            //        $" in the database.");
            //    return NotFound();
            //}

            var fridgeModelEntity = HttpContext.Items["fridgeModel"] as FridgeModel;

            _mapper.Map(fridgeModelForUpdateDto, fridgeModelEntity);
            await _repositoryManager.SaveAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        [ServiceFilter(typeof(ValidateFridgeModelForFridgeExistsAttribute))]
        public async Task<IActionResult> PartiallyUpdateFridgeModelForFridge(Guid fridgeId,
            Guid id, [FromBody] JsonPatchDocument<FridgeModelForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                _loggerManager.LogError("patchDoc object sent from client is null.");
                return BadRequest("patchDoc object is null.");
            }

            //var fridge = await _repositoryManager.Fridge.GetFridgeAsync(fridgeId, trackChanges: false);

            //if (fridge == null)
            //{
            //    _loggerManager.LogInfo($"Fridge with id: {fridgeId} doesn't exist" +
            //        $" in the database.");
            //    return NotFound();
            //}

            //var fridgeModelEntity = await _repositoryManager.FridgeModel
            //    .GetFridgeModelAsync(fridgeId, id, trackChanges: true);

            //if (fridgeModelEntity == null)
            //{
            //    _loggerManager.LogInfo($"FridgeModel with id: {id} doesn't exist" +
            //        $" in the database.");
            //    return NotFound();
            //}

            var fridgeModelEntity = HttpContext.Items["fridgeModel"] as FridgeModel;

            var fridgeModelToPatch = _mapper.Map<FridgeModelForUpdateDto>(fridgeModelEntity);

            patchDoc.ApplyTo(fridgeModelToPatch, ModelState);

            TryValidateModel(fridgeModelToPatch);

            if (!ModelState.IsValid)
            {
                _loggerManager.LogError("Invalid model state for the patch document.");
                return UnprocessableEntity(ModelState);
            }

            _mapper.Map(fridgeModelToPatch, fridgeModelEntity);

            await _repositoryManager.SaveAsync();

            return NoContent();
        }
    }
}
