using Exo_2.Data;
using Exo_2.DTOs;
using Exo_2.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exo_2.Controllers
{
    [Route("api/v1/songs")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SongsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var music = _context.Music.ToList();

            return Ok(music);
        }

        [HttpGet("{MusicId}")]
        public IActionResult GetById(int MusicId)
        {
            var musicTrouve = _context.Music.FirstOrDefault(Music => Music.Id == MusicId);

            if (musicTrouve == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(musicTrouve);
            }
        }

        [HttpPost]
        public IActionResult CreateDog([FromBody] MusicCreationRequest payload)
        {
            var musicTitre = payload.Titre;
            var musicInterpretre = payload.Interpretre;
            var musicGenreMusic = payload.GenreMusic;
            var musicTempDeMusic = TimeSpan.Parse(payload.TempDeMusic);
            var musicNote = int.Parse(payload.Note);

            var dateArray = payload.DateDeSortie.Split('/');

            var day = int.Parse(dateArray[0]);
            var month = int.Parse(dateArray[1]);
            var year = int.Parse(dateArray[2]);

            var musiqueDoB = new DateOnly(year, month, day);

            var newMusic = new Musique()
            {
                Titre = musicTitre,
                Interpretre = musicInterpretre,
                DateDeSortie = musiqueDoB,
                GenreMusic = musicGenreMusic,
                TempDeMusic = musicTempDeMusic,
                Note = musicNote
            };

            _context.Music.Add(newMusic);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { Id = newMusic.Id }, newMusic);
        }




    }
}
