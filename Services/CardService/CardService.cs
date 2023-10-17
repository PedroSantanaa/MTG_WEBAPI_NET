using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MTG_WebAPI_NET.Data;
using MTG_WebAPI_NET.Dtos.Card;
using MTG_WebAPI_NET.Models;
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
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CardService(IMapper mapper, DataContext context)
        {
            this._mapper = mapper;
            this._context = context;
        }
        public async Task<ServiceResponse<List<GetCardDTO>>> AddCard(AddCardDTO newCard)
        {
            var serviceResponse = new ServiceResponse<List<GetCardDTO>>();
            var card = _mapper.Map<Card>(newCard);
            card.Id = cards.Max(c => c.Id) + 1;
            cards.Add(card);
            serviceResponse.Data = cards.Select(c => _mapper.Map<GetCardDTO>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCardDTO>>> DeleteCard(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCardDTO>>();
            var cardToDelete = cards.FirstOrDefault(c => c.Id == id);
            if (cardToDelete != null)
            {
                cards.Remove(cardToDelete);
                serviceResponse.Data = cards.Select(c => _mapper.Map<GetCardDTO>(c)).ToList();
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Card not found.";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCardDTO>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<List<GetCardDTO>>();
            var dbCards = await _context.Cards.ToListAsync();
            serviceResponse.Data = dbCards.Select(c => _mapper.Map<GetCardDTO>(c)).ToList();
            return serviceResponse;

        }

        public async Task<ServiceResponse<GetCardDTO>> GetSingle(int id)
        {
            var serviceResponse = new ServiceResponse<GetCardDTO>();
            var dbCard = await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCardDTO>(dbCard);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCardDTO>> UpdateCard(UpdateCardDTO updatedCard)
        {
            var serviceResponse = new ServiceResponse<GetCardDTO>();
            var cardToUpdate = cards.FirstOrDefault(card => card.Id == updatedCard.Id);
            if (cardToUpdate != null)
            {
                cardToUpdate.Name = updatedCard.Name;
                cardToUpdate.Strength = updatedCard.Strength;
                cardToUpdate.Defense = updatedCard.Defense;
                cardToUpdate.ManaValue = updatedCard.ManaValue;
                cardToUpdate.CollectionSet = updatedCard.CollectionSet;
                serviceResponse.Data = _mapper.Map<GetCardDTO>(cardToUpdate);
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Card not found.";
            }
            return serviceResponse;
        }
    }
}