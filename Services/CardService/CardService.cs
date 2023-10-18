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
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CardService(IMapper mapper, DataContext context)
        {
            this._mapper = mapper;
            this._context = context;
        }
        public async Task<ServiceResponse<AddCardDTO>> AddCard(AddCardDTO newCard)
        {
            var serviceResponse = new ServiceResponse<AddCardDTO>();
            var cardToDb = _mapper.Map<Card>(newCard);
            await _context.Cards.AddAsync(cardToDb);
            await _context.SaveChangesAsync();
            var card = _mapper.Map<AddCardDTO>(newCard);
            serviceResponse.Data = card;
            serviceResponse.Message = "Card added.";
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCardDTO>> DeleteCard(int id)
        {
            var serviceResponse = new ServiceResponse<GetCardDTO>();
            var cardToDelete = await _context.Cards.FindAsync(id);
            if (cardToDelete != null)
            {
                _context.Cards.Remove(cardToDelete);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetCardDTO>(cardToDelete);
                serviceResponse.Message = "Card deleted.";
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

        public async Task<ServiceResponse<GetCardDTO>> UpdateCard(int id, UpdateCardDTO updatedCard)
        {
            var serviceResponse = new ServiceResponse<GetCardDTO>();
            var cardToUpdate = await _context.Cards.FindAsync(id);
            if (cardToUpdate is not null)
            {
                cardToUpdate.Name = updatedCard.Name;
                cardToUpdate.Strength = updatedCard.Strength;
                cardToUpdate.Defense = updatedCard.Defense;
                cardToUpdate.ManaValue = updatedCard.ManaValue;
                cardToUpdate.CollectionSet = updatedCard.CollectionSet;
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetCardDTO>(cardToUpdate);
                serviceResponse.Message = "Card updated.";
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