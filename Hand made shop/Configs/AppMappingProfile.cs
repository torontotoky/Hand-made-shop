using AutoMapper;
using HandMadeShop.bll.models;
using HandMadeShop.dal.entites;

namespace Hand_made_shop.Configs
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<BUser, User>().ReverseMap();
            CreateMap<BToy, Toy>().ReverseMap();
        }
    }
}
