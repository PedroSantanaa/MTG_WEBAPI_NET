using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_NET.Models;

namespace MTG_WebAPI_NET.Services.CardService
{
    public class CardService : ICardService
    {
        private static List<Card> cards = new List<Card>{
            new Card {
            Id = 1,
            Name = "Lotus Cobra",
            Strength = 2,
            Defense = 1,
            ManaValue = "1G",
            CollectionSet = Collection.ZendikarRising},
            new Card {
            Id = 2,
            Name = "Scute Swarm",
            Strength = 1,
            Defense = 1,
            ManaValue = "2G",
            CollectionSet = Collection.ZendikarRising}};
        public List<Card> AddCard(Card newCard)
        {
            cards.Add(newCard);
            return cards;
        }

        public List<Card> GetAll()
        {
            return cards;
        }

        public Card GetSingle(int id)
        {
            var card = cards.FirstOrDefault(card => card.Id == id);
            if (card is not null)
            {
                return card;
            }
            throw new Exception("Card not found");
        }
    }
}