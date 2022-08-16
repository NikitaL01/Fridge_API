using AutoMapper;
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
            CreateMap<FridgeProducts, FridgeProductsDto>();
            CreateMap<Products, ProductsDto>();
            CreateMap<FridgeForCreationDto, Fridge>();
            CreateMap<FridgeModelForCreationDto, FridgeModel>();
            CreateMap<FridgeModelForUpdateDto, FridgeModel>().ReverseMap();
            CreateMap<FridgeForUpdateDto, FridgeDto>();
            CreateMap<FridgeForUpdateDto, Fridge>();
            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
