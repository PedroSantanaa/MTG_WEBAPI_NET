using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_NET.Models;

namespace MTG_WebAPI_NET.Dtos.Card
{
    public class UpdateCardDTO
    {
        public required string Name { get; set; }
        public required int Strength { get; set; }
        public required int Defense { get; set; }
        public required string ManaValue { get; set; }
        public required Collection CollectionSet { get; set; }
    }
}