using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_NET.Models;

    public class Card
    {
       public int Id { get; set; }
       public required string Name { get; set; } 
       public required int Strength { get; set; } 
       public required int Defense { get; set; } 
       public required string ManaValue {get;set;} 
       public required Collection CollectionSet { get; set; } 
    }
