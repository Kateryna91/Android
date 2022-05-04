using AutoMapper;
using Shop.Data.Entities;
using Shop.Data.Entities.Identity;
using Shop.Models;
using System.Globalization;

namespace Shop.Mapper
{
    public class AppMapProfile : Profile
    {
        public AppMapProfile()
        {
            var cultureInfo = new CultureInfo("uk-UA");
            //"23.9 - 12,5";
            CreateMap<CreateProductViewModel, ProductEntity>()
                .ForMember(x => x.Image, opt => opt.Ignore())
                .ForMember(x => x.DateCreated, opt => opt.MapFrom(x =>
                    DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc)))

                .ForMember(x => x.Price, opt => opt.MapFrom(x =>
                       Decimal.Parse(x.Price, cultureInfo)));

            CreateMap<ProductEntity, ProductItemViewModel>()
               .ForMember(x => x.DateCreated, opt => opt.MapFrom(x =>
                    x.DateCreated.ToString("dd.MM.yyyy HH:mm:ss")))
               .ForMember(x => x.Price, opt => opt.MapFrom(x => x.Price.ToString(cultureInfo)));

            CreateMap<RegisterViewModel, AppUser>()
              .ForMember(x => x.Photo, opt => opt.Ignore())
              .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.Email));

            CreateMap<AppUser, UserItemViewModel>()
                .ForMember(x => x.Photo, opt => opt.MapFrom(x => $"/images/{x.Photo}"));
        }
    }
}
