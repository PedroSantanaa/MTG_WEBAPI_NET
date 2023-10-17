using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MTG_WebAPI_NET.Dtos.Card;
using WebAPI_NET.Models;

namespace MTG_WebAPI_NET
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Card,GetCardDTO>();
            CreateMap<AddCardDTO,Card>();
        }
    }
}