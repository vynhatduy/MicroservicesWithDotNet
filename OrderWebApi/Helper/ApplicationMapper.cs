using AutoMapper;
using OrderWebApi.Data;
using OrderWebApi.Model;

namespace OrderWebApi.Helper
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Order,OrderModel>().ReverseMap();
            CreateMap<OrderDetail,OrderDetailModel>().ReverseMap();
        }
    }
}
