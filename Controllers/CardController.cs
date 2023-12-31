using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MTG_WebAPI_NET.Dtos.Card;
using MTG_WebAPI_NET.Models;
using MTG_WebAPI_NET.Services.CardService;
using Swashbuckle.AspNetCore.Annotations;
using WebAPI_NET.Models;

namespace MTG_WebAPI_NET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            this._cardService = cardService;
        }

        [HttpGet("GetAllCards")]
        [SwaggerOperation("Get All Cards")]
        public async Task<ActionResult<ServiceResponse<List<GetCardDTO>>>> GetAll()
        {
            return Ok(await _cardService.GetAll());
        }

        [HttpGet("{id}")]
        [SwaggerOperation("Get Card By Id")]
        public async Task<ActionResult<ServiceResponse<GetCardDTO>>> GetSingle(int id)
        {
            return Ok(await _cardService.GetSingle(id));
        }

        [HttpPost]
        [SwaggerOperation("Create a new Card")]
        public async Task<ActionResult<ServiceResponse<List<GetCardDTO>>>> AddCard(AddCardDTO newCard)
        {
            return Ok(await _cardService.AddCard(newCard));
        }

        [HttpPut]
        [SwaggerOperation("Update a Card")]
        public async Task<ActionResult<ServiceResponse<GetCardDTO>>> UpdateCard(int id, UpdateCardDTO updatedCard)
        {
            return Ok(await _cardService.UpdateCard(id, updatedCard));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation("Delete a Card")]
        public async Task<ActionResult<ServiceResponse<List<GetCardDTO>>>> DeleteCard(int id)
        {
            return Ok(await _cardService.DeleteCard(id));
        }
    }
}