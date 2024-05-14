using AutoMapper;
using UserWebApi.Data;
using UserWebApi.Model;

namespace UserWebApi.Helper
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<User,UserModel>().ReverseMap();
            CreateMap<UserRole, UserRoleModel>().ReverseMap();
        }
    }
}
