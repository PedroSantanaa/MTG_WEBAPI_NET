using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MTG_WebAPI_NET.Services.CardService;
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
        public ActionResult<List<Card>> GetAll()
        {
            return Ok(_cardService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Card> GetSingle(int id)
        {
            return Ok(_cardService.GetSingle(id));
        }

        [HttpPost("AddCard")]
        public ActionResult<List<Card>> AddCard(Card newCard)
        {
            return Ok(_cardService.AddCard(newCard)); }
    }
}