using AutoMapper;
using PKWebApp.Data.Entities;
using PKWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKWebApp.Data
{
    public class PKMappingProfile : Profile
    {
        public PKMappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(o => o.OrderId, ex => ex.MapFrom(o => o.Id))
                .ReverseMap();
        }
    }
}
