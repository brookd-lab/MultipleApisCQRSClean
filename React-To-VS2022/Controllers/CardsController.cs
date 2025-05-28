using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using React_To_VS2022.Data;
using React_To_VS2022.Models;

namespace React_To_VS2022.Controllers
{
    public class CardsController : Controller
    {
        private readonly CardsDbContext _context;

        public CardsController(CardsDbContext context)
        {
            _context = context;

            // Seed data if database is empty
            if (!_context.Cards.Any())
            {
                _context.Cards.AddRange(
                    new Card { Title = "Welcome Card", Description = "This is your first card.", Author = "DB" },
                    new Card { Title = "Blazor Demo", Description = "Explore Blazor features with this card.", Author = "David" },
                    new Card { Title = "Sample Card", Description = "Feel free to add or remove cards.", Author = "Sam" }
                );
                _context.SaveChanges();
            }
        }

        public ActionResult Index()
        {
            var cards = _context.Cards.ToList();
            return View(cards);
        }

        [HttpPost]
        public ActionResult Add(Card card)
        {
            _context.Cards.Add(card);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var card = _context.Cards.FirstOrDefault(c => c.Id == id);
            if (card != null)
            {
                _context.Cards.Remove(card);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var card = _context.Cards.FirstOrDefault(c => c.Id == id);
            if (card == null) return NotFound();
            return View(card);
        }

        // GET: Cards/Update/5
        public ActionResult Update(int id)
        {
            var card = _context.Cards.FirstOrDefault(c => c.Id == id);
            if (card == null) return NotFound();
            return View(card);
        }

        // POST: Cards/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Card card)
        {
            if (!ModelState.IsValid)
                return View(card);

            var existing = _context.Cards.FirstOrDefault(c => c.Id == card.Id);
            if (existing == null) return NotFound();

            existing.Title = card.Title;
            existing.Description = card.Description;
            existing.Author = card.Author;
            _context.SaveChanges();

            return RedirectToAction("Details", new { id = card.Id });
        }
    }
}
