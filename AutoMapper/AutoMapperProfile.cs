using AutoMapper;
using MangaStore.Models;
using MangaStore.ViewModels;
namespace MangaStore.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();
            CreateMap<Product, EditProductViewModel>();
            CreateMap<EditProductViewModel, Product>();
        }
    }
}
