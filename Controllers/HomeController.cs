using System.Diagnostics;
using Memo.Context;
using Memo.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Memo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var playlists = _context.Playlists.ToList();
            return View(playlists);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                _context.Playlists.Add(playlist);
                _context.SaveChanges();
                return RedirectToAction(nameof(Details), new { id = playlist.Id });
            }

            return View(playlist);
        }
        public async Task<IActionResult> Details(int id)
        {
            var playlist = await _context.Playlists
                .Include(p => p.Musics)
                .FirstOrDefaultAsync(p => p.Id == id);

            var playlists = _context.Playlists.ToList();

            if (playlist == null)
                return RedirectToAction(nameof(Index));

            var viewModel = new PlaylistViewModel
            {
                Playlist = playlist,
                Playlists = playlists,
            };

            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            var playlist = _context.Playlists.Find(id);

            if (playlist == null)
                return RedirectToAction(nameof(Index));

            return View(playlist);
        }

        [HttpPost]
        public IActionResult Edit(Playlist playlist)
        {
            var playlistBanco = _context.Playlists.Find(playlist.Id);

            if (playlistBanco == null)
                return BadRequest();

            playlistBanco.Name = playlist.Name;
            playlistBanco.ImageUrl = playlist.ImageUrl;

            _context.Playlists.Update(playlistBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Details), new { id = playlist.Id });
        }

        public IActionResult Delete(int id)
        {
            var playlist = _context.Playlists.Find(id);

            if (playlist == null)
                return RedirectToAction(nameof(Index));

            return View(playlist);
        }

        [HttpPost]
        public IActionResult Delete(Playlist playlist)
        {
            var playlistBanco = _context.Playlists.Find(playlist.Id);


            if (playlistBanco == null)
                return BadRequest();

            _context.Playlists.Remove(playlistBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddSong(int id)
        {

            var playlist = _context.Playlists.Find(id);
            var playlists = _context.Playlists.ToList();

            if (playlist == null)
                return RedirectToAction(nameof(Index));

            var viewModel = new PlaylistViewModel
            {
                Playlist = playlist,
                Playlists = playlists,
                Music = new Music()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddSong(Music music)
        {
            if (music == null)
                return BadRequest(music);

            var playlist = _context.Playlists.Find(music.PlaylistId);
            var newMusic = new Music
            {
                Name = music.Name,
                Author = music.Author,
                Link = music.Link,
                PlaylistId = music.PlaylistId,
            };

            _context.Musics.Add(newMusic);
            _context.SaveChanges();
            return RedirectToAction(nameof(Details), new { id = playlist!.Id });
        }
        public IActionResult EditSong(int id)
        {
            var song = _context.Musics.Find(id);
            
            if (song == null)
                return RedirectToAction(nameof(Details));

            var playlist = _context.Playlists.Find(song.PlaylistId);

            if (playlist == null)
                return RedirectToAction(nameof(Details));

            var playlists = _context.Playlists.ToList();


            var viewModel = new PlaylistViewModel
            {
                Playlist = playlist,
                Playlists = playlists,
                Music = song
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditSong(Music music)
        {
            if (music == null)
                return BadRequest(music);

            var existingMusic = _context.Musics.Find(music.Id);

            if (existingMusic == null)
                return NotFound();

            existingMusic.Name = music.Name;
            existingMusic.Author = music.Author;
            existingMusic.Link = music.Link;

            _context.Musics.Update(existingMusic);
            _context.SaveChanges();
            return RedirectToAction(nameof(Details), new { id = music.PlaylistId });
        }

        public IActionResult SeeSong(int id)
        {
            var song = _context.Musics.Find(id);
            if (song == null)
                return RedirectToAction(nameof(Details));

            var playlist = _context.Playlists
                .Include(p => p.Musics)
                .FirstOrDefault(p => p.Id == song.PlaylistId);

            if (playlist == null)
                return RedirectToAction(nameof(Details));

            playlist.Musics = playlist.Musics.OrderBy(m => m.Id).ToList();

            var playlists = _context.Playlists.ToList();

            var viewModel = new PlaylistViewModel
            {
                Playlist = playlist,
                Playlists = playlists,
                Music = song
            };

            return View(viewModel);
        }

        public IActionResult DeleteSong(int id)
        {
            var song = _context.Musics.Find(id);

            if (song == null)
                return RedirectToAction(nameof(Details));

            var playlist = _context.Playlists.Find(song.PlaylistId);

            if (playlist == null)
                return RedirectToAction(nameof(Details));

            var playlists = _context.Playlists.ToList();


            var viewModel = new PlaylistViewModel
            {
                Playlist = playlist,
                Playlists = playlists,
                Music = song
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult DeleteSong(Music music)
        {
            var id = music.PlaylistId;

            if (music == null)
                return BadRequest(music);

            _context.Musics.Remove(music);
            _context.SaveChanges();

            return RedirectToAction(nameof(Details), new { id = id});
        }
    }
}
