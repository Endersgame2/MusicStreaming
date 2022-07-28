using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicStreaming.Models.Database;
using MusicStreaming.Models.ViewModel;
using System.Linq;
using System;

namespace MusicStreaming.Controllers
{
    public class StoreController : Controller
    {
        private readonly ILogger<StoreController> _logger;
        private readonly MusicStreamingContext _context;
        public StoreController(ILogger<StoreController> logger, MusicStreamingContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if(userId == 0 || userId == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var latestTimeStamp = DateTime.UtcNow.AddDays(-30);
            var query = from song in _context.Songs
                        join order in _context.Orders on song.Id equals order.SongId into leftJoin
                        from orderSet in leftJoin.DefaultIfEmpty()
                        select new SongItem()
                        {

                            SongId = song.Id,
                            SongName = song.Name,
                            IsOrdered = orderSet.Id > 0,
                            IsRefundAvailable = orderSet.TimeStamp >= latestTimeStamp
                        };
            var vm = new StoreView
            {
                SongItems = query.ToList()
            };
            return View(vm);
        }
        public IActionResult Buy([FromQuery]string songId)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var user = _context.Users.FirstOrDefault(user => user.Id == userId);
            if (user != null && int.TryParse(songId, out int songIdInt))
            {
                var song = _context.Songs.FirstOrDefault(song => song.Id == songIdInt);
                if(song.Price != null && song.Price > user.Balance)
                {
                    return StatusCode(402);
                }
                try
                {
                    _context.Database.BeginTransaction();
                    if(song.Price != null)
                    {
                        user.Balance -= song.Price;
                    }
                    _context.Orders.Add(new Order()
                    {
                        UserId = (int)userId,
                        SongId = songIdInt,
                        TimeStamp = DateTime.UtcNow
                    });
                    _context.SaveChanges();
                    _context.Database.CommitTransaction();
                    return Ok();
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, "Purchase error by user: " + userId + ", songId: " + songId);
                    _context.Database.RollbackTransaction();
                    return RedirectToAction("Error", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult Refund([FromQuery]string songId)
        {
            if (int.TryParse(songId, out int songIdInt))
            {
                var userId = HttpContext.Session.GetInt32("UserId");
                var user = _context.Users.FirstOrDefault(x => x.Id == userId);
                if (user == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                var order = _context.Orders.FirstOrDefault(x => x.SongId == songIdInt && x.UserId == userId);
                var song = _context.Songs.FirstOrDefault(x => x.Id == order.SongId);
                var latestTimeStamp = DateTime.UtcNow.AddDays(-30);
                if(order?.TimeStamp < latestTimeStamp)
                {
                    return BadRequest();
                }
                try
                {
                    _context.Database.BeginTransaction();
                    _context.Orders.Remove(order);
                    
                    if(song.Price != null)
                    {
                        user.Balance += song.Price;
                    }
                    _context.SaveChanges();
                    _context.Database.CommitTransaction();
                    return Ok();
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, "Refund error for order: " + order.Id);
                    _context.Database.RollbackTransaction();
                    return RedirectToAction("Error", "Home");
                }
            }
            return RedirectToAction("Error", "Home");
        }
    }
}
