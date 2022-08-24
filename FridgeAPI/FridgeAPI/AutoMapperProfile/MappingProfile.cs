﻿using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace FridgeAPI.AutoMapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Fridge, FridgeDto>();
            CreateMap<FridgeModel, FridgeModelDto>();
            CreateMap<FridgeProduct, FridgeProductDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<FridgeForCreationDto, Fridge>();
            CreateMap<FridgeModelForCreationDto, FridgeModel>();
            CreateMap<FridgeForCreationDto, FridgeProduct>();
            CreateMap<ProductForCreationDto, Product>();
            CreateMap<FridgeForUpdateDto, FridgeDto>();
            CreateMap<FridgeModelForUpdateDto, FridgeModel>().ReverseMap();
            CreateMap<FridgeProductForUpdateDto, FridgeProduct>().ReverseMap();
            CreateMap<ProductForUpdateDto, Product>();
            CreateMap<FridgeForUpdateDto, Fridge>();
            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
