using AutoMapper;
using ProductWebApi.Data;
using ProductWebApi.Model;

namespace ProductWebApi.Helper
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Product,ProductModel>().ReverseMap();
            CreateMap<Category,CategoryModel>().ReverseMap();
        }
    }
}
