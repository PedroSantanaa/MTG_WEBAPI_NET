using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_NET.Models;

namespace MTG_WebAPI_NET.Services.CardService
{
    public interface ICardService
    {
        List<Card> GetAll();
        Card GetSingle(int id);
        List<Card> AddCard(Card newCard);
    }
}