using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ChallengePapaBobsSi.Persistence;

namespace ChallengePapaBobsSi.Persistence.Repositories
{
    public static class AutoMapperPersistenceConfiguration
    {
        public static MapperConfiguration MapperConfiguration;

        public static void RegisterMappings()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DTO.CustomerOrderDTO, CustomerOrder>(MemberList.Source).PreserveReferences().ReverseMap();
                cfg.CreateMap<DTO.PizzaSizeDTO, PizzaSize>(MemberList.Source).PreserveReferences().ReverseMap();
                cfg.CreateMap<DTO.PizzaCrustDTO, PizzaCrust>(MemberList.Source).PreserveReferences().ReverseMap();
                cfg.CreateMap<DTO.PizzaToppingDTO, PizzaTopping>(MemberList.Source).PreserveReferences().ReverseMap();
            });
        }
    }
}