using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MTG_WebAPI_NET.Dtos.Card;
using MTG_WebAPI_NET.Models;
using WebAPI_NET.Models;

namespace MTG_WebAPI_NET.Services.CardService
{
    public interface ICardService
    {
        Task<ServiceResponse<List<GetCardDTO>>> GetAll();
        Task<ServiceResponse<GetCardDTO>> GetSingle(int id);
        Task<ServiceResponse<List<GetCardDTO>>> AddCard(AddCardDTO newCard);
        Task<ServiceResponse<GetCardDTO>> UpdateCard(UpdateCardDTO updatedCard);
        Task<ServiceResponse<List<GetCardDTO>>> DeleteCard(int id);
    }
}