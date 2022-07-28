using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using MusicStreaming.Models;
using MusicStreaming.Models.Database;
using MusicStreaming.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStreaming.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MusicStreamingContext _context;
        public HomeController(ILogger<HomeController> logger, MusicStreamingContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index([FromQuery] string userId = "")
        {
            UserCollectionView vm = new UserCollectionView
            {
                Users = _context.Users.Select(user => new KeyValuePair<int, string>(user.Id, user.Email)).ToList()
            };
            if (!string.IsNullOrEmpty(userId) && int.TryParse(userId, out int userIdInt))
            {
                var collections = _context.UserCollections.Where(collection => collection.UserId == userIdInt).ToList();
                vm.UserCollectionItems = collections.SelectMany(collection =>
                {
                    var songIds = _context.UserCollectionSongMappings.Where(mapping => mapping.UserCollectionId == collection.Id).Select(mapping => mapping.SongId).ToList();
                    return _context.Songs.Where(song => songIds.Contains(song.Id)).Select((song) =>
                    new UserCollectionItem()
                    {
                        SongName = song.Name,
                        ArtistName = _context.Artists.FirstOrDefault(artist => artist.Id == song.ArtistId).Name,
                        CollectionName = collection.Name
                    }).ToList();
                }).OrderBy(item => item.ArtistName).ToList();
            }
            return View(vm);
        }

        public IActionResult Artists([FromQuery] string artistId = "")
        {
            ArtistView vm = new ArtistView
            {
                Artists = _context.Artists.Select(artist => new KeyValuePair<int, string>(artist.Id, artist.Name)).ToList()
            };
            if (!string.IsNullOrEmpty(artistId) && int.TryParse(artistId, out int artistIdInt))
            {
                // TO-DO: Fill ArtistViewItems
            }
            return View(vm);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
