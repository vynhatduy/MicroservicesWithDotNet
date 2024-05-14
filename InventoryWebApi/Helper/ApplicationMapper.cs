using AutoMapper;
using InventoryWebApi.Data;
using InventoryWebApi.Model;

namespace InventoryWebApi.Helper
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Product,ProductModel>().ReverseMap();
        }
    }
}
