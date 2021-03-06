﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PopPopTradingCardsLib.Interfaces;
using PopPopTradingCardsDataAccess;
using Lib = PopPopTradingCardsLib.Models;
using Microsoft.AspNetCore.Http;
using PopPopTradingCardsWebUI.Models;
using Newtonsoft.Json;

namespace PopPopTradingCardsWebUI.Controllers
{
    public class CardController : Controller
    {

        private readonly IRepository _repo;

        public CardController(IRepository repo)
        {
            _repo = repo;
        }

        public IActionResult MyCollections()
        {
            if (HttpContext.Session.Id == null)
            {
                object o;
                TempData.TryGetValue("Id", out o);
                HttpContext.Session.SetInt32("Id", JsonConvert.DeserializeObject<Int32>((string)o));
                object p;
                TempData.TryGetValue("Username", out p);
                HttpContext.Session.SetString("Username", JsonConvert.DeserializeObject<String>((string)p));
            }
            var Cards = _repo.GetMagicCards(HttpContext.Session.GetInt32("Id"));
            if(Cards.Count()>0)
            {
                ViewBag.MTG = "yes";
            }
            var Cards2 = _repo.GetBaseballCards(HttpContext.Session.GetInt32("Id"));
            if (Cards2.Count() > 0)
            {
                ViewBag.Baseball = "yes";
            }
            return View();
        }
        public IActionResult ViewMagicCards()
        {
            var Cards = _repo.GetMagicCards(HttpContext.Session.GetInt32("Id"));
            return View(Cards);
        }
        public IActionResult MagicCardDetails([FromRoute]int id = 1)
        {
            TempData["id"] = id;
            Lib.MagicCard card = _repo.GetMagicCard(id);
            EditLocation l = new EditLocation()
            {
                Card = card
            };
            return View(l);
        }
        public IActionResult OtherMagicCardDetails([FromRoute]int id=1)
        {
            TempData["id"] = id;
            Lib.MagicCard card = _repo.GetMagicCard(id);
            EditLocation l = new EditLocation()
            {
                Card = card
            };
            return View(l);
        }
        public IActionResult OtherCollections()
        {
            return View();
        }
        public IActionResult OtherCollectionsView()
        {
            return View();
        }
        public IActionResult AddCard()
        {
            return View();
        }
        public IActionResult AddCardAction(CardTypeViewModel c, IFormCollection form)
        {
            ViewBag.UserId = HttpContext.Session.GetString("Id");
            AddMagicCardViewModels model = new AddMagicCardViewModels();
            if (c.cardType == "MTG")
            {
                var Cards = _repo.GetMagicCards(-1);
                model.MagicCards = Cards.ToList();
                return View("CreateMagicCard", model);
            }
            else
            {
                var Cards = _repo.GetBaseballCards(-1);
                return View("CreateBaseballCard", model);
            }
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

        public IActionResult DeleteMagicCard()
        {
            int id = Convert.ToInt32(TempData["id"].ToString());
            _repo.DeleteMagicCard(id);
            var Cards = _repo.GetMagicCards(HttpContext.Session.GetInt32("Id"));
            if (Cards.Count() > 0)
            {
                ViewBag.MTG = "yes";
            }
            var Cards2 = _repo.GetBaseballCards(HttpContext.Session.GetInt32("Id"));
            if (Cards2.Count() > 0)
            {
                ViewBag.Baseball = "yes";
            }
            return View("MyCollections");
        }
        public IActionResult PutMagicCard(EditLocation c, IFormCollection form)
        {
            try
            {
                int id = Convert.ToInt32(TempData["id"].ToString());
                TempData["id"] = id;
                c.Card = _repo.GetMagicCard(id);
                c.Card.Location = c.NewLocation;
                _repo.PutMagicCard(c.Card);
                EditLocation l = new EditLocation()
                {
                    Card = c.Card
                };
                return View("MagicCardDetails", l);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        // Post a new Magic card to the database
        public IActionResult PostMagicCard(AddMagicCardViewModels c, IFormCollection form)
        {
            try
            {
                Lib.MagicCard ca = _repo.GetMagicCard(c.id);
                Lib.MagicCard card = new Lib.MagicCard()
                {
                    Booster = ca.Booster,
                    CMC = ca.CMC,
                    Color = ca.Color,
                    Image = ca.Image,
                    Location = c.Location,
                    Name = ca.Name,
                    Rarity = ca.Rarity,
                    Type = ca.Type,
                    UserId = Convert.ToInt32(HttpContext.Session.GetInt32("Id"))
                };
                _repo.PostMagicCard(card);
                var Cards = _repo.GetMagicCards(HttpContext.Session.GetInt32("Id"));
                if (Cards.Count() > 0)
                {
                    ViewBag.MTG = "yes";
                }
                var Cards2 = _repo.GetBaseballCards(HttpContext.Session.GetInt32("Id"));
                if (Cards2.Count() > 0)
                {
                    ViewBag.Baseball = "yes";
                }
                return View("MyCollections");
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

        [HttpGet]
        public IActionResult OtherCollection(int id)
        {
            var user = _repo.GetUserById(id);
            TempData["otherid"] = id;
            if(user != null)
            {
                var model = new OtherCollectionViewModel
                {
                    Username = user.Username,
                    MagicCards = _repo.GetMagicCards(user.Id),
                    BaseballCards = _repo.GetBaseballCards(user.Id)
                };

                return View(model);
            }

            return View("Error");
        }
        public IActionResult ViewOtherMagicCards()
        {
            var Cards = _repo.GetMagicCards(Convert.ToInt32(TempData["otherid"].ToString()));
            return View(Cards);
        }
    }
}