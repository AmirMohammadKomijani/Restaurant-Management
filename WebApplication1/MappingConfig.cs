using AutoMapper;
using WebApplication1.Model;
using WebApplication1.Model.DTO.FoodDTOs;
using WebApplication1.Model.DTO.ChefDTOs;
using WebApplication1.Model.DTO.CustomerDTOs;
using WebApplication1.Model.DTO.UpdateFoodDto;
using WebApplication1.Model.DTO.UpdateChefDto;

namespace WebApplication1
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Food, GetFoodDto>().ReverseMap();
            CreateMap<Food, CreateFoodDto>().ReverseMap();
            CreateMap<Food, UpdateFoodDto>().ReverseMap();

            CreateMap<Chef, GetChefDto>().ReverseMap();
            CreateMap<Chef, CreateChefDto>().ReverseMap();
            CreateMap<Chef, UpdateChefDto>().ReverseMap();

            CreateMap<Customer, GetCustomerDto>().ReverseMap();
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
        }
    }
}
