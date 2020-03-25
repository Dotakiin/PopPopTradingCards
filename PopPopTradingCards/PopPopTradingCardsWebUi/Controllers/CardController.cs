using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PopPopTradingCardsWebUI.Controllers
{
    public class CardController : Controller
    {

        // Get list of Magic Cards
        public IActionResult MagicIndex()
        {
            return View();
        }

        // Get list of Baseball Cardsd
        public IActionResult BaseballIndex()
        {
            return View();
        }

        // Get a specific Magic card by its Id
        public IActionResult GetMagicCard(int id)
        {
            return View();
        }

        // Get a specific Baseball card by its Id
        public IActionResult GetBaseballCard(int id)
        {
            return View();
        }

        // Post a new Magic card to the database
        public IActionResult PostMagicCard(/*MagicCard card*/)
        {
            return View();
        }

        // Post a new Baseball card to the database
        public IActionResult PostBaseballCard(/*BaseballCard card*/)
        {
            return View();
        }

        // Update an existing Magic card
        public IActionResult PutMagicCard(/*MagicCard card*/)
        {
            return View();
        }

        // Update an existing Baseball card
        public IActionResult PutBaseballCard(/*BaseballCard card*/)
        {
            return View();
        }

        // Delete an existing Magic card by its Id
        public IActionResult DeleteMagicCard(int id)
        {
            return View();
        }

        // Delete an existing Baseball card by its Id
        public IActionResult DeleteBaseballCard(int id)
        {
            return View();
        }
    }
}