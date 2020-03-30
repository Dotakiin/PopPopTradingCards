using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PopPopTradingCardsLib.Interfaces;
using PopPopTradingCardsDataAccess;
using Lib = PopPopTradingCardsLib.Models;

namespace PopPopTradingCardsWebUI.Controllers
{
    public class CardController : Controller
    {

        private readonly IRepository _repo;

        public CardController(IRepository repo)
        {
            _repo = repo;
        }

        // Get list of Magic Cards
        public IActionResult MagicIndex()
        {
            try
            {
                var Cards = _repo.GetMagicCards();

                return View(Cards);
            }
            catch(Exception)
            {
                return BadRequest();
            }
            
        }

        // Get list of Baseball Cardsd
        public IActionResult BaseballIndex()
        {
            try
            {
                var Cards = _repo.GetBaseballCards();

                return View(Cards);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        // Get a specific Magic card by its Id
        public IActionResult GetMagicCard(int id)
        {
            try
            {
                var Card = _repo.GetMagicCard(id);

                return View(Card);
            }
            catch(Exception)
            {
                return NotFound();
            }
        }

        // Get a specific Baseball card by its Id
        public IActionResult GetBaseballCard(int id)
        {
            try
            {
                var Card = _repo.GetBaseballCard(id);

                return View(Card);
            }
            catch(Exception)
            {
                return NotFound();
            }
        }

        // Post a new Magic card to the database
        public IActionResult PostMagicCard(Lib.MagicCard card)
        {
            try
            {
                _repo.PostMagicCard(card);

                return NoContent();
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        // Post a new Baseball card to the database
        public IActionResult PostBaseballCard(Lib.BaseballCard card)
        {
            try
            {
                _repo.PutBaseballCard(card);

                return NoContent();
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        // Update an existing Magic card
        public IActionResult PutMagicCard(Lib.MagicCard card)
        {
            try
            {
                _repo.PutMagicCard(card);

                return NoContent();
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        // Update an existing Baseball card
        public IActionResult PutBaseballCard(Lib.BaseballCard card)
        {
            try
            {
                _repo.PutBaseballCard(card);

                return NoContent();
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        // Delete an existing Magic card by its Id
        public IActionResult DeleteMagicCard(int id)
        {
            try
            {
                _repo.DeleteMagicCard(id);

                return NoContent();
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        // Delete an existing Baseball card by its Id
        public IActionResult DeleteBaseballCard(int id)
        {
            try
            {
                _repo.DeleteBaseballCard(id);

                return NoContent();
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }
    }
}