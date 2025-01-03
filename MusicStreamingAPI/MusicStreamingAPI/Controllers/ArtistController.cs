using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStreamingAPI.Models;
using System;

namespace MusicStreamingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Artist>> GetArtists()
        {
            return Ok(MusicData.Artists);  // Return all artists
        }

        [HttpGet("{id}")]
        public ActionResult<Artist> GetArtist(int id)
        {
            // Find the artist by its ID
            var artist = MusicData.Artists.FirstOrDefault(a => a.Id == id);
            if (artist == null)
            {
                return NotFound();
            }

            // Return artist details
            return Ok(artist);
        }

        [HttpPost]
        public ActionResult AddArtist(Artist artist)
        {
            if (MusicData.Artists.Any(a => a.Id == artist.Id))
            {
                return BadRequest("Artist with this ID already exists.");
            }

            MusicData.Artists.Add(artist);
            return CreatedAtAction(nameof(GetArtist), new { id = artist.Id }, artist);
        }

        [HttpPut("{id}")]
        public ActionResult<Artist> UpdateArtist(int id, Artist updatedArtist)
        {
            if (id != updatedArtist.Id)
            {
                return BadRequest("The provided ids don't match.");
            }

            var artist = MusicData.Artists.FirstOrDefault(x => x.Id == id);

            if (artist == null)
            {
                return NotFound("The artist doesn't exist.");
            }

            if (artist != null)
            {
                artist.Name = updatedArtist.Name;
            }

            return Ok(artist);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteArtist(int id)
        {
            var artist = MusicData.Artists.FirstOrDefault(s => s.Id == id);

            if (artist == null)
            {
                return NotFound();
            }

            MusicData.Artists.Remove(artist);

            return NoContent();
        }
    }
}
