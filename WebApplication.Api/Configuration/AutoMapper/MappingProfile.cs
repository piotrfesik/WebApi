using AutoMapper;
using WebApplication.Api.ViewModels;
using WebApplication.Data.DataModels.Configurations;
using WebApplication.Data.DataModels.Laptops;
using WebApplication.Services.DtoModels;

namespace WebApplication.Api.Configuration.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ConfigurationItem, ConfigurationItemDtoModel>()
                .ForMember(dest => dest.Id,
                    opts =>
                        opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Cost,
                    opts =>
                        opts.MapFrom(src => src.Cost))
                .ForMember(dest => dest.ConfigurationType,
                    opts =>
                        opts.MapFrom(src=>src.ConfigurationItemType))
                .ForPath(dest => dest.ConfigurationType.Id,
                    opts =>
                        opts.MapFrom(src => src.ConfigurationTypeId))
                .ForMember(dest => dest.Name,
                    opts =>
                        opts.MapFrom(src => src.Name));
            
            CreateMap<ConfigurationItemDtoModel, ConfigurationItem>()
                .ForMember(dest => dest.Id,
                    opts =>
                        opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Cost,
                    opts =>
                        opts.MapFrom(src => src.Cost))
                .ForMember(dest => dest.ConfigurationItemType,
                    opts =>
                        opts.Ignore())
                .ForPath(dest => dest.ConfigurationTypeId,
                    opts =>
                        opts.MapFrom(src => src.ConfigurationType.Id))
                .ForMember(dest => dest.Name,
                    opts =>
                        opts.MapFrom(src => src.Name));

            CreateMap<ConfigurationItemViewModel, ConfigurationItemDtoModel>()
                .ForMember(dest => dest.Id,
                    opts =>
                        opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Cost,
                    opts =>
                        opts.MapFrom(src => src.Cost))
                .ForMember(dest => dest.ConfigurationType,
                    opts =>
                        opts.MapFrom(src => src.ConfigurationType))
                .ForMember(dest => dest.Name,
                    opts =>
                        opts.MapFrom(src => src.Name))
                .ReverseMap();

            CreateMap<ConfigurationTypeDtoModel, ConfigurationType>()
                .ForMember(dest => dest.Id,
                    opts =>
                        opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.TypeName,
                    opts =>
                        opts.MapFrom(src => src.TypeName))
                .ReverseMap();

            CreateMap<ConfigurationTypeViewModel, ConfigurationTypeDtoModel>()
                .ForMember(dest => dest.Id,
                    opts =>
                        opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.TypeName,
                    opts =>
                        opts.MapFrom(src => src.TypeName))
                .ReverseMap();

            CreateMap<LaptopsDtoModel, Laptop>().ReverseMap();
            
            CreateMap<LaptopsViewModel, LaptopsDtoModel>()
                .ForMember(dest => dest.Brand,
                    opts =>
                        opts.Ignore())
                .ForMember(dest => dest.Id,
                    opts =>
                        opts.Ignore())
                .ReverseMap();
            
            CreateMap<BrandDtoModel, Brand>().ReverseMap();
            CreateMap<BrandViewModel, BrandDtoModel>().ReverseMap();
            CreateMap<LaptopConfigurationDtoView, LaptopConfiguration>().ReverseMap();

            CreateMap<LaptopConfigurationViewModel, LaptopConfigurationDtoView>()
                .ForMember(dest => dest.ConfigurationItem,
                    opts =>
                        opts.Ignore())
                .ReverseMap();
            
            CreateMap<BasketDtoModel, Basket>()
                .ForMember(dest => dest.Id,
                    opts =>
                        opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.LaptopId,
                    opts =>
                        opts.MapFrom(src => src.LaptopId))
                .ForMember(dest => dest.Laptop,
                    opts =>
                        opts.MapFrom(src => src.Laptop))
                .ReverseMap();
            
            CreateMap<BasketViewModel, BasketDtoModel>().ReverseMap();
        }
    }
}